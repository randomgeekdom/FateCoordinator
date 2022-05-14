using FateCoordinator.Contracts;

namespace FateCoordinator.Repositories
{
    public interface IGameRepository
    {
        Task<GameDto> AddAsync(Guid userId, string name);
        Task DeleteAsync(Guid userId, Guid gameId);
        Task<IEnumerable<GameDto>> GetAllAsync(Guid userId);
        Task<GameDto> GetAsync(Guid userId, Guid gameId);
        Task SaveAsync(Guid userId, GameDto game);
    }
}