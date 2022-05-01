using Bot.Data.Context;
using Bot.Data.Models.ContextModels;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Modules
{
    // Modules must be public and inherit from an IModuleBase
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        private readonly ApplicationDbContext _context;

        public PublicModule(ApplicationDbContext context)
        {
           _context = context;
        }

        [Command("ping")]
        [Alias("pong", "hello")]
        public async Task PingAsync()
        {
            await _context.SyncRequests.AddAsync(new SyncRequest() { DiscordId = Context.User.Id.ToString()});
            await _context.SaveChangesAsync();
            await ReplyAsync("pong!");
        }

    }
}
