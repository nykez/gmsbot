using Bot.Data;
using Bot.Data.Context;
using Bot.Data.Services;
using Bot.Worker;
using Bot.Worker.Handlers;
using Discord;
using Discord.Addons.Hosting;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;

try
{
    var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(app =>
    {
        var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, true)
        .AddEnvironmentVariables().Build();
        app.AddConfiguration(config);
        app.AddCommandLine(args);
    })
    .ConfigureLogging(logging =>
    {
        logging.AddConsole();
        logging.SetMinimumLevel(LogLevel.Debug);
    })
    .ConfigureDiscordHost(async (context, config) =>
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
    })
    .ConfigureServices((context, services) =>
    {
        services.AddScoped<AppConfigService>();
        services.AddHostedService<CommandHandler>();
        services.AddHostedService<InteractionHandler>();
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("Web")));
    }).UseConsoleLifetime();

    var app = host.Build();
    await app.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine(ex.StackTrace);
    throw;
}