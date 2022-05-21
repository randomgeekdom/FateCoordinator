using FateCoordinator.Contracts;

namespace FateCoordinator.Services
{
    public class StressTrackFactory : IStressTrackFactory
    {
        public List<Stress> GetTrack(int level, bool isCondensed)
        {
            var numberOfBoxes = 2;
            if (level >= 1)
            {
                numberOfBoxes++;
            }
            if (level >= 3)
            {
                numberOfBoxes++;
            }

            var list = new List<Stress>();
            for (int i = 1; i <= numberOfBoxes; i++)
            {
                list.Add(new Stress
                {
                    Level = isCondensed ? 1 : i
                });
            }

            return list;
        }
    }
}
