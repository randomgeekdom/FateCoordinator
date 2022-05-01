using FateCoordinator.Contracts;

namespace FateCoordinator.Repositories
{
    public interface ICharacterRepository
    {
        Task<CharacterDto> GetCharacterAsync(Guid userId, Guid characterId);
        Task<CharacterDto> AddCharacterAsync(Guid userId, string name);

        Task<IEnumerable<CharacterDto>> GetAllAsync(Guid userId);
        Task SaveCharacterAsync(Guid userId, CharacterDto character);
        Task DeleteCharacterAsync(Guid userId, Guid characterId);
    }
}