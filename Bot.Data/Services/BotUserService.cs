using Bot.Data.Models.ContextModels;
using Bot.Data.Processors;
using Bot.Data.Repos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Data.Services
{
    public class BotUserService
    {
        private readonly ILogger<BotUserService> _logger;
        private readonly BotUserProcessor _userProcessor;
        private readonly SyncRequestProcessor _syncProcessor;
        private readonly GmodstoreService _gmodstoreService;
        private readonly RolesRepo _rolesRepo;
        private readonly DiscordUserManager _discordUserManager;

        public BotUserService(ILogger<BotUserService> logger, BotUserProcessor userProcessor, SyncRequestProcessor syncProcessor,
            GmodstoreService gmodstoreService, RolesRepo rolesRepo, DiscordUserManager discordUserManager)
        {
            _logger = logger;
            _userProcessor = userProcessor;
            _syncProcessor = syncProcessor;
            _gmodstoreService = gmodstoreService;
            _rolesRepo = rolesRepo;
            _discordUserManager = discordUserManager;
        }

        public async Task<BotUser> GetAsync(ulong id)
        {
            var user = await _userProcessor.GetUserById(id);
            return user!;
        }

        public async Task<BotUser> CreateOrUpdateUserAsync(Guid id, string steamId)
        {
            try
            {
                var request = await _syncProcessor.GetRequestById(id);
                if (request == null)
                    throw new InvalidOperationException("No GUID present for this request user");

                var isValidUser = await _userProcessor.GetUserById(request.DiscordId!);
                if (isValidUser != null)
                    return isValidUser;

                // create user
                BotUser user = new();
                user.DiscordId = request.DiscordId;
                user.SteamId = steamId;
                user.CreatedAt = DateTime.UtcNow;
                user.UpdatedAt = DateTime.UtcNow;
                user.UpdatedByUser = "root";
                user.CreatedByUser = "root";

                await _userProcessor.CreateUser(user);
                await UpdateUserRoles(user);

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error attempting to create bot user: {id}:{steamId}", ex);
                throw;
            }
        }

        private async Task UpdateUserRoles(BotUser user)
        {
            // fetch what addons the user has
            var currentRoles = await _rolesRepo.GetAllRoles();
            var addons = (await _gmodstoreService.GetProductPurchasesAsync(user.SteamId)).Data;
            List<ulong> rolesToAdd = new();

            foreach(var role in currentRoles)
            {
                var t = addons.Any(u => u!.ProductId == role.ScriptId);
                if (t)
                {
                    rolesToAdd.Add(role.DiscordRoleId!.Value);
                }
            }

            await _discordUserManager.UpdateRoles(461702012258746390, user.DiscordId, rolesToAdd);
        }
    }
}
