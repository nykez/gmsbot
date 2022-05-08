using Bot.Data.Models.ContextModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Bot.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ScriptUserRole>().HasOne(t => t.User).WithMany(t => t.Roles);

            // seed some app config options
            builder.Entity<AppConfig>().HasData(new AppConfig()
            { Key = AppConfigConstants.SteamApiKey, Value = "" }, new AppConfig()
            { Key = AppConfigConstants.BotToken, Value = "" }, new AppConfig()
            { Key = AppConfigConstants.GmsToken, Value = "" }, new AppConfig()
            { Key = AppConfigConstants.AppUrl, Value = "www.google.com" });

            var adminRole = new IdentityRole()
            { Id = Guid.NewGuid().ToString(), Name = "Admin" };

            builder.Entity<IdentityRole>().HasData(adminRole);
            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            { Name = "Support Rep" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            { Name = "Moderator" });


            var appUser = new AppUser
            {
                UserName = "admin@admin.com",
                NormalizedUserName = "admin@admin.com",
                Email = "admin@admin.com",
                NormalizedEmail =  "ADMIN@ADMIN.COM",
                LockoutEnabled = false,
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                Id = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };
            var passwordHasher = new PasswordHasher<AppUser>();
            var password =  passwordHasher.HashPassword(appUser, "Admin*123");
            appUser.PasswordHash = password;

            builder.Entity<AppUser>().HasData(appUser);

            var adminRoleSet = new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = appUser.Id
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoleSet);

            var userStore = new UserStore<AppUser>(this);

            builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
            { Id = 1, UserId = appUser.Id, ClaimType = ClaimTypes.Role, ClaimValue = "Admin"});


            base.OnModelCreating(builder);
        }

        public DbSet<SyncRequest> SyncRequests => Set<SyncRequest>(); 
        public DbSet<BotUser> BotUsers => Set<BotUser>();
        public DbSet<ScriptRole> ScriptRoles => Set<ScriptRole>();
        public DbSet<ScriptUserRole> ScriptUserRoles => Set<ScriptUserRole>();
        public DbSet<AppConfig> AppConfig => Set<AppConfig>();
    }
}
