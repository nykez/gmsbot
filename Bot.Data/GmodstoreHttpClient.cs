using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Bot.Data.Services;
using Bot.Data;

namespace Bot.Http
{
    public class GmodstoreHttpClient<TModel> where TModel : class
    {
        private readonly ILogger<GmodstoreHttpClient<TModel>> _logger;
        private readonly HttpClient _client;
        private readonly AppConfigService _appConfigService;

        public GmodstoreHttpClient(ILogger<GmodstoreHttpClient<TModel>> logger, HttpClient client, AppConfigService appConfigService)
        {
            _logger = logger;
            _client = client;
            _appConfigService = appConfigService;
            _client.BaseAddress = new Uri("https://api.gmodstore.com/v3/");
            _client.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("Bearer", _appConfigService.GetConfigItemSingle(AppConfigConstants.GmsToken).Value);
        }

        public async Task<List<TModel>> GetListAsync(string route)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + route);
                response.EnsureSuccessStatusCode();
                var model = await response!.Content!.ReadFromJsonAsync<List<TModel>>();
                return model!;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching API list resource: {route}", ex);
                throw;
            }
        }

        public async Task<TModel> GetAsync(string route)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + route);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var model = await response!.Content!.ReadFromJsonAsync<TModel>();
                return model!;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching API resource: {route}", ex);
                throw;
            }
        }

    }
}
