using Bot.Data.Context;
using Bot.Data.Models;
using Bot.Data.Models.ContextModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Data
{
    public class AppConfigOptions : IConfigureOptions<AppConfiguration>
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public AppConfigOptions(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void Configure(AppConfiguration options)
        {
            using var scope = _scopeFactory.CreateScope();
            var provider = scope.ServiceProvider;
            using var dbContext = provider.GetRequiredService<ApplicationDbContext>();
            options.Config = dbContext.AppConfig.ToList();
        }
    }
}
