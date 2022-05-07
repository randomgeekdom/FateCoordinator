using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace FateCoordinator.Extensions
{
    public static class IdentityExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            string val = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            if(!Guid.TryParse(val, out var id))
            {
                id = new Guid();
            }

            return id;
        }

        public static async Task<Guid> GetUserIdAsync(this AuthenticationStateProvider authenticationStateProvider)
        {
            return GetUserId((await authenticationStateProvider.GetAuthenticationStateAsync()).User);
        }
    }
}