using FateCoordinator.Model.Characters;
using Microsoft.EntityFrameworkCore;

namespace FateCoordinator.Repositories
{
    public interface IFateCoordinatorContext
    {
        DbSet<Character> Characters { get; }

        Task<int> SaveChangesAsync();
    }
}