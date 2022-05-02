using Bot.Data.Context;
using Bot.Data.Models.ContextModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Data.Processors
{
    public class DiscordUserProcessor
    {
        private readonly ApplicationDbContext _context;
        private readonly SyncRequestProcessor _syncRequestProcessor;

        public DiscordUserProcessor(ApplicationDbContext context, SyncRequestProcessor syncRequestProcessor)
        {
            _context = context;
            _syncRequestProcessor = syncRequestProcessor;
        }

        public async Task<DiscordUser> CreateOrUpdateUser(Guid syncId, string discordId, string steamId)
        {
            var user = await _context.DiscordUsers.Where(u => u.DiscordId == discordId).FirstOrDefaultAsync();

            if (user == null)
            {
                user = new DiscordUser();
                user.DiscordId = discordId;
                user.SteamId = steamId;

                _context.DiscordUsers.Add(user);
                await _context.SaveChangesAsync();

            }

            await _syncRequestProcessor.DeleteRequestById(syncId);

            return user;
        }
    }
}
