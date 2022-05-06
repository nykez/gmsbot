using System.ComponentModel.DataAnnotations;

namespace Bot.Data.Models.ContextModels
{
    public class BotUser: IAuditEntity
    {
        [Key]
        public ulong DiscordId { get; set; }
        public string? SteamId { get; set; }
        public string? CreatedByUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedByUser { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual List<ScriptUserRole>? Roles { get; set; }
    }
}
