using FateCoordinator.Model.Characters;
using FateCoordinator.Model.Games;
using Microsoft.EntityFrameworkCore;

namespace FateCoordinator.Repositories
{
    public interface IFateCoordinatorContext
    {
        DbSet<Character> Characters { get; }
        DbSet<Game> Games { get; set; }

        Task<int> SaveChangesAsync();
    }
}