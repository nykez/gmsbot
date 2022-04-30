using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bot.Models
{
    public class SyncRequest
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? DiscordId { get; set; }
        public DateTime CreatedAt { get; set; }

        public SyncRequest()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
