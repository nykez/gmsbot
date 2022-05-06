using Bot.Data;
using Bot.Data.Context;
using Bot.Data.Models;
using Bot.Data.Models.ContextModels;
using Bot.Data.Processors;
using Bot.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Web")));
builder.Services.AddSingleton<IConfigureOptions<AppConfiguration>, AppConfigOptions>();
builder.Services.AddAuthentication(options => { })
    .AddSteam(o =>
    {
        o.ApplicationKey = builder.Configuration["SteamApiKey"];
    });
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<AppUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<SyncRequestProcessor>();
builder.Services.AddTransient<BotUserProcessor>();
builder.Services.AddTransient<BotUserService>();
builder.Services.AddTransient<AppConfigService>();
builder.Services.AddGmodstoreServices();
builder.Host.AddDiscordBot(builder.Services);


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
