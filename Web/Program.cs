using AspNet.Security.OpenId.Steam;
using Bot.Data;
using Bot.Data.Context;
using Bot.Data.Models;
using Bot.Data.Models.ContextModels;
using Bot.Data.Processors;
using Bot.Data.Repos;
using Bot.Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// load app config
AppConfiguration appConfig = new AppConfiguration();
var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>();
dbOptions.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Web"));
using (var dbContext = new ApplicationDbContext(dbOptions.Options))
{
    var didCreate = dbContext.Database.EnsureCreated();
    if (didCreate)
    {
        dbContext.Database.Migrate();
    }
    if (dbContext.AppConfig != null)
    {
        var settings = await dbContext!.AppConfig!.ToListAsync();
        appConfig.Config = settings;
    }
}

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Web")));
builder.Services.AddSingleton<IConfigureOptions<AppConfiguration>, AppConfigOptions>();
builder.Services.AddAuthentication(options => { })
    .AddSteam(o =>
    {
        o.ApplicationKey = appConfig!.Config!.First(u => u.Key! == AppConfigConstants.SteamApiKey).Value!;
    });
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<AppUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SyncRequestProcessor>();
builder.Services.AddScoped<BotUserProcessor>();
builder.Services.AddScoped<BotUserService>();
builder.Services.AddScoped<AppConfigService>();
builder.Services.AddScoped<RolesRepo>();
builder.Services.AddScoped<UserRolesRepo>();
builder.Services.AddScoped<DiscordUserManager>();
builder.Services.AddGmodstoreServices();
builder.Host.AddDiscordBot(builder.Services, appConfig!.Config!.First(u => u.Key == AppConfigConstants.BotToken).Value!);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
