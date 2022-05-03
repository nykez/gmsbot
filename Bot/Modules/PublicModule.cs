using Bot.Data.Context;
using Bot.Data.Models.ContextModels;
using Bot.Data.Services;
using Bot.Services;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bot.Modules
{
    // Modules must be public and inherit from an IModuleBase
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        private readonly BotUserService _manager;

        public PublicModule(BotUserService manager)
        {
            _manager = manager;
        }

        [Command("ping")]
        [Alias("pong", "hello")]
        public async Task PingAsync()
        {
            var user = await _manager.GetAsync(Context.User.Id.ToString());
            await ReplyAsync("pong!" + JsonSerializer.Serialize(user));
        }

    }
}
