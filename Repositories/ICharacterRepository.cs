namespace FateCoordinator.Repositories
{
    public interface ICharacterRepository
    {
        Task<CharacterDto> AddCharacterAsync(Guid userId, string name);

        Task<IEnumerable<CharacterDto>> GetAllAsync(Guid userId);
    }
}