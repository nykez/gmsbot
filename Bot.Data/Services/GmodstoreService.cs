
using Bot.Data.Models.HttpModels;
using Bot.Http;
using Everyday.GmodStore.Sdk.Model;

namespace Bot.Data.Services
{
    public class GmodstoreService
    {
        private readonly GmodstoreHttpClient<ProductPurchasesResponse> _productsPurchaseApi;

        public GmodstoreService(GmodstoreHttpClient<ProductPurchasesResponse> productsPurchaseApi)
        {
            _productsPurchaseApi = productsPurchaseApi;
        }

        public async Task<ProductPurchasesResponse> GetProductPurchasesAsync(string? userId)
        {
            return await _productsPurchaseApi.GetAsync($"users/{userId}/purchases");
        }
    }
}
