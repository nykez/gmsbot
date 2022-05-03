using System.ComponentModel.DataAnnotations;


namespace Bot.Data.Models.ContextModels
{
    public class ScriptRole
    {
        [Key]
        public int Id { get; set; }
        public string? ScriptId { get; set; }
        public string? DiscordRoleId { get; set; }
    }
}
