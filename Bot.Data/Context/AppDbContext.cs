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

            builder.Entity<ScriptUserRole>().HasOne(t => t.User).WithMany(t => t.Roles);

            base.OnModelCreating(builder);
        }

        public DbSet<SyncRequest> SyncRequests => Set<SyncRequest>(); 
        public DbSet<BotUser> BotUsers => Set<BotUser>();
        public DbSet<ScriptRole> ScriptRoles => Set<ScriptRole>();
        public DbSet<ScriptUserRole> ScriptUserRoles => Set<ScriptUserRole>();
        public DbSet<AppConfig> AppConfig => Set<AppConfig>();
    }
}
