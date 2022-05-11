using FateCoordinator.Contracts;

namespace FateCoordinator.Services
{
    public interface IDieRollerService
    {
        DiceRollResult RollDice(int modifier = 0);
    }
}