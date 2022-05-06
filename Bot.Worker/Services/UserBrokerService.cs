using Discord.WebSocket;

namespace Bot.Services
{
    public class UserBrokerService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

            }
        }
    }
}
