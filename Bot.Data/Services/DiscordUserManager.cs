using Discord;
using Discord.WebSocket;

namespace Bot.Data.Services
{
    public class DiscordUserManager
    {
        private readonly DiscordSocketClient _discordClient;

        public DiscordUserManager(DiscordSocketClient discordClient)
        {
            _discordClient = discordClient;
        }

        public async Task UpdateRoles(ulong guildId, ulong userId, List<ulong> roles)
        {
            try
            {
                IGuild guild = _discordClient.GetGuild(guildId);

                if (guild == null)
                    return;

                IGuildUser guildUser = await guild.GetUserAsync(userId);

                if (guildUser == null)
                    return;

                foreach (var role in roles)
                {
                    await guildUser.AddRoleAsync(role);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemoveRoles(ulong guildId, ulong userId, List<ulong> roles)
        {
            try
            {
                IGuild guild = _discordClient.GetGuild(guildId);

                if (guild == null)
                    return;

                IGuildUser guildUser = await guild.GetUserAsync(userId);

                if (guildUser == null)
                    return;

                foreach (var role in roles)
                {
                    await guildUser.RemoveRoleAsync(role);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
