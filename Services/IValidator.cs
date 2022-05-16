using FateCoordinator.Contracts;

namespace FateCoordinator.Services
{
    public interface IValidator
    {
        IEnumerable<string> ValidateCharacter(CharacterDto character);
    }
}