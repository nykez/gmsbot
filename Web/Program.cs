using Bot.Data.Context;
using Bot.Data.Models.ContextModels;
using Bot.Data.Processors;
using Bot.Data.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddAuthentication(options => {})
    .AddSteam(o =>
    {
       o.Events = new AspNet.Security.OpenId.OpenIdAuthenticationEvents
       {
           OnRedirectToIdentityProvider = (context) =>
           {
               var guidId = context.Request.Query.FirstOrDefault(x => x.Key == "guidId");
               context.ProtocolMessage.SetParameter("guidId", guidId.Value);
               return Task.CompletedTask;
           }
       };
        o.ApplicationKey = builder.Configuration["SteamApiKey"];
    });
builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Web")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<AppUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddGmodstoreServices(builder.Configuration["Gmodstore:AccessToken"]);
builder.Services.AddScoped<SyncRequestProcessor>();
builder.Services.AddScoped<BotUserService>();

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
