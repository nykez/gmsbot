using Bot.Data.Context;
using Bot.Data.Models.ContextModels;
using Bot.Services;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Modules
{
    public class SyncRoleModule : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly InteractionHandler _handler;
        private readonly ApplicationDbContext _context;

        public InteractionService? Commands { get; set; }

        public SyncRoleModule(InteractionHandler handler, ApplicationDbContext context)
        {
            _handler = handler;
            _context = context;
        }


        [SlashCommand("sync", "Sync roles with matching gmodstore addons")]
        public async Task SyncRolesAsync([Summary(description: "Mention the user")] SocketGuildUser user)
        {
            await RespondAsync("Syncing your roles!");
        }

        [SlashCommand("create", "testing 123")]
        public async Task DoSomethingAsync()
        {
            await _context.SyncRequests.AddAsync(new SyncRequest() { Id = new Guid()});
            await _context.SaveChangesAsync();
            await RespondAsync("I created the record sir.");
        }
    }
}
