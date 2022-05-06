﻿using Bot.Worker.Handlers;
using Discord;
using Discord.Addons.Hosting;
using Discord.Commands;
using Discord.WebSocket;

namespace Web.Extensions
{
    public static class DiscordConfiguration
    {
        public static void AddDiscordBot(this IHostBuilder hostBuilder, IServiceCollection services)
        {
            hostBuilder.ConfigureDiscordHost(async (context, config) =>
            {
                config.SocketConfig = new DiscordSocketConfig
                {
                    LogLevel = LogSeverity.Verbose,
                    AlwaysDownloadUsers = true,
                    MessageCacheSize = 200
                };

                config.Token = context.Configuration["Token"];
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
    }
}