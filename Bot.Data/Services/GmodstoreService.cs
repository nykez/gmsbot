
using Bot.Data.Models.HttpModels;
using Bot.Http;
using Everyday.GmodStore.Sdk.Model;

namespace Bot.Data.Services
{
    public class GmodstoreService
    {
        private readonly GmodstoreHttpClient<ProductPurchasesResponse> _productsPurchaseApi;
        private readonly GmodstoreHttpClient<UserResponse> _userClient;

        public GmodstoreService(GmodstoreHttpClient<ProductPurchasesResponse> productsPurchaseApi, GmodstoreHttpClient<UserResponse> userClient)
        {
            _productsPurchaseApi = productsPurchaseApi;
            _userClient = userClient;
        }

        public async Task<ProductPurchasesResponse> GetProductPurchasesAsync(string? userId)
        {
            return await _productsPurchaseApi.GetAsync($"users/{userId}/purchases");
        }

        public async Task<UserResponse> GetUserAsync(string steamId)
        {
            return await _userClient.GetAsync($"users?filter[steamId]={steamId}");
        }
    }
}
