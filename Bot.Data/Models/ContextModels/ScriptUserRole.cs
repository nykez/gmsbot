using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bot.Data.Models.ContextModels
{
    public class ScriptUserRole
    {
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public BotUser? User { get; set; }
        public virtual ScriptRole? Role { get; set; }
    }
}
