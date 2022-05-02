using Bot.Data.Models.ContextModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bot.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SyncRequest>().HasData(
                new SyncRequest { Id = Guid.NewGuid() });

            base.OnModelCreating(builder);
        }

        public DbSet<SyncRequest> SyncRequests => Set<SyncRequest>(); 
        public DbSet<DiscordUser> DiscordUsers => Set<DiscordUser>();
    }
}
