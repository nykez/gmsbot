using Bot.Data;
using Bot.Data.Context;
using Bot.Data.Models;
using Bot.Data.Processors;
using Bot.Data.Services;
using Bot.Services;
using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;

namespace Bot
{
    public class Program
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _services;

        private readonly DiscordSocketConfig _socketConfig = new()
        {
            GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.GuildMembers,
            AlwaysDownloadUsers = true,
        };

        public Program()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables(prefix: "gms_")
                .AddJsonFile("token.json", optional: true)
                .Build();

            var connectionString = _configuration.GetConnectionString("DefaultConnection");


            _services = new ServiceCollection()
                .AddLogging( options =>
                {
                    options.ClearProviders();
                    options.AddConsole();
                })
                .AddSingleton(_configuration)
                .AddSingleton(_socketConfig)
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandService>()
                .AddSingleton(x => new InteractionService(x.GetRequiredService<DiscordSocketClient>()))
                .AddSingleton<InteractionHandler>()
                .AddSingleton<CommandHandlerService>()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Web")))
                .AddSingleton<IConfigureOptions<AppConfiguration>, AppConfigOptions>()
                .AddScoped<SyncRequestProcessor>()
                .AddScoped<BotUserProcessor>()
                .AddScoped<BotUserService>()
                .AddScoped<AppConfigService>()
                .BuildServiceProvider();
        }

        static void Main(string[] args)
            => new Program().RunAsync()
                .GetAwaiter()
                .GetResult();

        public async Task RunAsync()
        {
            Log.Logger = new LoggerConfiguration()
               .WriteTo.File("logs/bot.log", rollingInterval: RollingInterval.Day)
               .CreateLogger();


            var client = _services.GetRequiredService<DiscordSocketClient>();
            var appConfig = _services.GetRequiredService<AppConfigService>();
            var token = await appConfig.GetConfigItem("bot_token");

            client.Log += LogAsync;
            _services.GetRequiredService<CommandService>().Log += LogAsync;

            // Here we can initialize the service that will register and execute our commands
            await _services.GetRequiredService<InteractionHandler>()
                .InitializeAsync();
            await _services.GetRequiredService<CommandHandlerService>()
                .InitializeAsync();

            // Bot token can be provided from the Configuration object we set up earlier
            await client.LoginAsync(TokenType.Bot, token.Value);
            await client.StartAsync();

            // Never quit the program until manually forced to.
            await Task.Delay(Timeout.Infinite);
        }

        private static Task LogAsync(LogMessage message)
        {
            var severity = message.Severity switch
            {
                LogSeverity.Critical => LogEventLevel.Fatal,
                LogSeverity.Error => LogEventLevel.Error,
                LogSeverity.Warning => LogEventLevel.Warning,
                LogSeverity.Info => LogEventLevel.Information,
                LogSeverity.Verbose => LogEventLevel.Verbose,
                LogSeverity.Debug => LogEventLevel.Debug,
                _ => LogEventLevel.Information
            };

            Log.Write(severity, message.Exception, "[{Source}] {Message}", message.Source, message.Message);
            Console.WriteLine(message.ToString());

            return Task.CompletedTask;
        }

        public static bool IsDebug()
        {
            #if DEBUG
                return true;
            #else
                 return false;
            #endif
        }
    }
}
