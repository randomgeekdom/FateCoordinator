using FateCoordinator.Contracts;

namespace FateCoordinator.Services
{
    public class DieRollerService : IDieRollerService
    {
        private readonly Random random = new();

        public DiceRollResult RollDice(int modifier = 0)
        {
            var result1 = this.Roll();
            var result2 = this.Roll();
            var result3 = this.Roll();
            var result4 = this.Roll();

            return new DiceRollResult
            {
                FirstResult = result1,
                SecondResult = result2,
                ThirdResult = result3,
                FourthResult = result4,
                Result = (int)result1 + (int)result2 + (int)result3 + (int)result4 + modifier
            };
        }

        private DieValue Roll()
        {
            return (DieValue)this.random.Next(-1, 2);
        }
    }
}
