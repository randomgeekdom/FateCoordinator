using FateCoordinator.Contracts;

namespace FateCoordinator.Services
{
    public interface IStressTrackFactory
    {
        List<Stress> GetTrack(int level, bool isCondensed);
    }
}