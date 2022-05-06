using Bot.Data.Models.ContextModels;
using Bot.Data.Processors;
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

        public BotUserService(ILogger<BotUserService> logger, BotUserProcessor userProcessor, SyncRequestProcessor syncProcessor)
        {
            _logger = logger;
            _userProcessor = userProcessor;
            _syncProcessor = syncProcessor;
        }

        public async Task<BotUser> GetAsync(string? id)
        {
            return await _userProcessor!.GetUserById(id)!;
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

        }
    }
}
