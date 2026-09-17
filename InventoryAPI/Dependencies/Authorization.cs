using Microsoft.AspNetCore.Authorization;

namespace InventoryAPI.Dependencies
{
    public static class Authorization
    {
        public static void AuthorizationDI(this IServiceCollection services)
        {
            var requiresAuth = new AuthorizationPolicyBuilder()
                                  .RequireAuthenticatedUser()
                                  .Build();

            services.AddAuthorizationBuilder().SetFallbackPolicy(requiresAuth);                
        }
    }
}
