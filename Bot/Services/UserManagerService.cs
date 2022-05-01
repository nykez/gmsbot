using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Services
{
    public class UserManagerService
    {
        private readonly DiscordSocketClient _client;

        public UserManagerService(DiscordSocketClient client)
        {
            _client = client;
        }

        public SocketGuildUser? GetUserAsync(ulong userId)
        {
            var user = _client.Guilds.First().GetUser(userId);
            return user;
        }

        public SocketGuildUser? RemoveRole(ulong userId, ulong role)
        {
            var user = GetUserAsync(userId);

            if (user == null)
                return null;

            user.RemoveRoleAsync(role);

            return user;
        }

        public SocketGuildUser? AddRole(ulong userId, ulong role)
        {
            var user = GetUserAsync(userId);

            if (user == null)
                return null;

            user.AddRoleAsync(role);

            return user;
        }
    }
}
