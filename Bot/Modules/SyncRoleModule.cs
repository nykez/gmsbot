using Bot.Services;
using Discord.Interactions;
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

        public InteractionService Commands { get; set; }

        public SyncRoleModule(InteractionHandler handler)
        {
            _handler = handler;
        }

        [SlashCommand("ping", "Pings the bot and returns its latency.")]
        public async Task GreetUserAsync()
        {
            await RespondAsync(text: $":ping_pong: It took me {Context.Client.Latency}ms to respond to you!", ephemeral: true);
        }
    }
}
