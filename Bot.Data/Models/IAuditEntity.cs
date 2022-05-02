using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Data.Models
{
    public interface IAuditEntity
    {
        string? CreatedByUser { get; set; }
        DateTime CreatedAt { get; set; }
        string UpdatedByUser { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
