using Everyday.GmodStore.Sdk.Api;
using Everyday.GmodStore.Sdk.Client;

namespace Web.Extensions
{
    public static class GmodstoreConfiguration
    {
        public static void AddGmodstoreServices(this IServiceCollection services, string accessToken)
        {
            Configuration config = new Configuration();
            config.BasePath = @"https://www.gmodstore.com";
            config.AccessToken = accessToken;

            services.AddSingleton(new UserAddonsApi(config));
            services.AddSingleton(new TeamsApi(config));
            services.AddSingleton(new UserBansApi(config));
        }
    }
}
