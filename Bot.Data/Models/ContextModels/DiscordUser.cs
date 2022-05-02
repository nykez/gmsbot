using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Data.Models.ContextModels
{
    public class DiscordUser
    {
        [Key]
        public string? DiscordId { get; set; }
        public string? SteamId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
