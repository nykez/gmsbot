using Bot.Data;
using Bot.Data.Context;
using Bot.Data.Processors;
using Bot.Data.Services;
using Bot.Worker.Handlers;
using Discord;
using Discord.Addons.Hosting;
using Discord.Commands;
using Discord.WebSocket;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Web.Extensions
{
    public static class DiscordConfiguration
    {
        public static void AddDiscordBot(this IHostBuilder hostBuilder, IServiceCollection services, string token)
        {
            try
            {
                hostBuilder.ConfigureDiscordHost(async (context, config) =>
                {
                    config.SocketConfig = new DiscordSocketConfig
                    {
                        LogLevel = LogSeverity.Verbose,
                        AlwaysDownloadUsers = true,
                        MessageCacheSize = 200
                    };

                    config.Token = !string.IsNullOrEmpty(token) ? token : context.Configuration["Token"];
                })
                //Omit this if you don't use the command service
                .UseCommandService((context, config) =>
                {
                    config.DefaultRunMode = RunMode.Async;
                    config.CaseSensitiveCommands = false;
                })
                .UseInteractionService((context, config) =>
                {
                    config.LogLevel = LogSeverity.Info;
                    config.UseCompiledLambda = false;
                });

                services.AddHostedService<CommandHandler>();
                services.AddHostedService<InteractionHandler>();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
