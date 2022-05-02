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
    public class BotUserProcessor
    {
        private readonly ApplicationDbContext _context;
        private readonly SyncRequestProcessor _syncRequestProcessor;

        public BotUserProcessor(ApplicationDbContext context, SyncRequestProcessor syncRequestProcessor)
        {
            _context = context;
            _syncRequestProcessor = syncRequestProcessor;
        }

        public async Task CreateUser(BotUser user)
        {
            _context.BotUsers.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<BotUser?> GetUserById(string discordId)
        {
            return await _context.BotUsers.Where(_u => _u.DiscordId == discordId).FirstOrDefaultAsync();
        }
    }
}
