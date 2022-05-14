using FateCoordinator.Extensions;
using Microsoft.AspNetCore.Components.Authorization;

namespace FateCoordinator.Services
{
    public class Limiter : ILimiter
    {
        public async Task<int> GetGameLimitAsync()
        {
            return 5;
        }
        public async Task<int> GetCharacterLimitAsync()
        {
            return 100;
        }
    }
}
