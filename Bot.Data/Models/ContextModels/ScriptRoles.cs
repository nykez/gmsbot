using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
