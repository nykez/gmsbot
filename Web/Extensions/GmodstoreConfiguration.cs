using Bot.Data.Models.HttpModels;
using Bot.Data.Services;
using Bot.Http;
using Everyday.GmodStore.Sdk.Api;
using Everyday.GmodStore.Sdk.Client;
using Everyday.GmodStore.Sdk.Model;

namespace Web.Extensions
{
    public static class GmodstoreConfiguration
    {
        public static void AddGmodstoreServices(this IServiceCollection services)
        {
            services.AddScoped<GmodstoreService>();
            services.AddScoped<GmodstoreHttpClient<ProductPurchasesResponse>>();
            services.AddScoped<GmodstoreHttpClient<UserResponse>>();
        }
    }
}
