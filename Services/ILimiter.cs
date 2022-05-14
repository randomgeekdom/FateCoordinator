
namespace FateCoordinator.Services
{
    public interface ILimiter
    {
        Task<int> GetGameLimitAsync();
        Task<int> GetCharacterLimitAsync();
    }
}