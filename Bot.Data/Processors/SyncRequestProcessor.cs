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
    public class SyncRequestProcessor
    {
        private readonly ApplicationDbContext _context;

        public SyncRequestProcessor(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsValidRequest(Guid id)
        {
            if (id == Guid.Empty)
                return false;

            return await _context.SyncRequests.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> UserHasRequest(string discordId)
        {
            return await _context.SyncRequests.AnyAsync(_ => _.DiscordId == discordId);
        }

        public async Task<SyncRequest> GetOrCreateRequest(string discordId)
        {
            var request = await _context.SyncRequests.FirstOrDefaultAsync(x => x.DiscordId == discordId);

            if (request == null)
            {
                request = new SyncRequest
                {
                    DiscordId = discordId
                };

                await _context.SyncRequests.AddAsync(request);
                await _context.SaveChangesAsync();

                return request;
            }
            else
            {
                return request;
            }
        }

        public async Task<SyncRequest> CreateRequest(string discordId)
        {
            var request = new SyncRequest() { DiscordId = discordId };

            await _context.SyncRequests.AddAsync(request);
            await _context.SaveChangesAsync();

            return request;
        }

        public async Task DeleteAllRequests(string discordId)
        {
            var records = await _context.SyncRequests.Where(x => x.DiscordId == discordId).ToListAsync();

            if (records == null || records.Count < 0)
                return;

            _context.SyncRequests.RemoveRange(records);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequestById(Guid id)
        {
            var request = await _context.SyncRequests.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (request == null)
                return;

            _context.SyncRequests.Remove(request!);
            await _context.SaveChangesAsync();
        }
    }
}
