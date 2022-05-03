using Bot.Data.Context;
using Bot.Data.Models;
using Bot.Data.Models.ContextModels;
using Microsoft.Extensions.Options;

namespace Bot.Data.Services
{
    public class AppConfigService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IOptionsSnapshot<AppConfiguration> _snapshot;

        public AppConfigService(ApplicationDbContext dbContext,
            IOptionsSnapshot<AppConfiguration> snapshot)
        {
            _dbContext = dbContext;
            _snapshot = snapshot;
        }

        public async Task<AppConfig> GetConfigItem(string? key)
        {
            var value = await Task.Run(() => _snapshot!.Value!.Config!.FirstOrDefault(u => u.Key == key));
            return value!;
        }

        public AppConfiguration GetConfig()
        {
            return _snapshot.Value;
        }

        public async Task<AppConfig?> SetConfigItemAsync(AppConfig? item)
        {
            if (item == null)
                return null;

            var configItem = _dbContext.AppConfig?.FirstOrDefault(u => u.Key == item.Key);

            if (configItem == null)
            {
                configItem = new AppConfig { Key = item.Key, Value = item.Value };
                await _dbContext!.AppConfig!.AddAsync(configItem);
            }
            else
            {
                configItem.Value = item.Value;
            }
            await _dbContext.SaveChangesAsync();
            UpdateCache(item.Key!, item.Value!);

            return configItem;
        }

        private void UpdateCache(string key, string value)
        {
            var configItem = _snapshot?.Value?.Config?.FirstOrDefault(u => u.Key == key);

            if (configItem != null)
                configItem.Value = value;
        }
    }
}
