using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace FateCoordinator.Extensions
{
    public static class IdentityExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            string val = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.Parse(val);
        }

        public static async Task<Guid> GetUserIdAsync(this AuthenticationStateProvider authenticationStateProvider)
        {
            return GetUserId((await authenticationStateProvider.GetAuthenticationStateAsync()).User);
        }
    }
}