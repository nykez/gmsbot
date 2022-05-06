using Discord.Interactions;
using Discord.WebSocket;

namespace Bot.Worker.Modules
{
    public class InteractionModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("sync", "Sync roles with matching gmodstore addons")]
        public async Task SyncRolesAsync([Summary(description: "Mention the user for sync")] SocketGuildUser user)
        {
            await RespondAsync($"Syncing {user.DisplayName} roles!");
        }
    }
}
