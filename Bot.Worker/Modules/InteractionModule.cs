using Bot.Data.Context;
using Bot.Data.Models.ContextModels;
using Bot.Data.Processors;
using Bot.Data.Services;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using System.Text.Json;

namespace Bot.Worker.Modules
{
    public class InteractionModule : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly IServiceProvider _provider;

        public InteractionModule(IServiceProvider provider)
        {
            _provider = provider;
        }

        [SlashCommand("sync", "Sync roles with matching gmodstore addons")]
        public async Task SyncRolesAsync([Summary(description: "Mention the user for sync")] SocketGuildUser user)
        {
            try
            {
                var guild = Context.Guild.Name;
                var syncId = await _provider.GetRequiredService<SyncRequestProcessor>().CreateRequest(user.Id);
                var appUrl = _provider.GetRequiredService<AppConfigService>().GetConfigItemSingle("app_url");
                var url = appUrl.Value + "sync/" + syncId.Id;
                await RespondAsync($"Syncing {user.DisplayName} roles!");
                await user.SendMessageAsync($"Hello! Please follow the url to sync your gmodstore roles with {guild}!: {url}");
            }
            catch (Discord.Net.HttpException)
            {
                await RespondAsync($"{user.DisplayName} does not have DMs open! Cannot sync roles!");
            }
        }
    }
}
