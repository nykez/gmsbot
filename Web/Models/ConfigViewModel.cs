using Bot.Data.Models;
using Bot.Data.Models.ContextModels;

namespace Web.Models
{
    public class ConfigViewModel
    {
        public AppConfiguration? Config { get; set; }
        public List<ScriptRole>? Roles { get; set; }
    }
}
