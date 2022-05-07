using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Data.Models.HttpModels
{
    public class UserDto
    {
        public string? Id { get; set; }
        public ulong? SteamId { get; set; }
        public string? Avatar { get; set; }
        public string? CreatedAt { get; set; }
    }
}
