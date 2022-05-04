using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Data.Models.HttpModels
{
    public class ProductPurchaseDto
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? ProductId { get; set; }
        public bool? Revoked { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
    }
}
