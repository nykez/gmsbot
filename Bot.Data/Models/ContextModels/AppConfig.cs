using System.ComponentModel.DataAnnotations;

namespace Bot.Data.Models.ContextModels
{
    public class AppConfig
    {
        [Key]
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}
