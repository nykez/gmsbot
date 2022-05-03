using Bot.Data.Models.ContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Data.Models
{
    public class AppConfiguration
    {
        public ICollection<AppConfig>? Config { get; set; }
    }
}
