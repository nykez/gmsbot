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
            builder.Entity<ScriptUserRole>().HasOne(t => t.User).WithMany(t => t.Roles);

            // seed some app config options
            builder.Entity<AppConfig>().HasData(new AppConfig()
            { Key = AppConfigConstants.SteamApiKey, Value = "" }, new AppConfig()
            { Key = AppConfigConstants.BotToken, Value = "" }, new AppConfig()
            { Key = AppConfigConstants.GmsToken, Value = "" }, new AppConfig()
            { Key = AppConfigConstants.AppUrl, Value = "www.google.com" });

            base.OnModelCreating(builder);
        }

        public DbSet<SyncRequest> SyncRequests => Set<SyncRequest>(); 
        public DbSet<BotUser> BotUsers => Set<BotUser>();
        public DbSet<ScriptRole> ScriptRoles => Set<ScriptRole>();
        public DbSet<ScriptUserRole> ScriptUserRoles => Set<ScriptUserRole>();
        public DbSet<AppConfig> AppConfig => Set<AppConfig>();
    }
}
