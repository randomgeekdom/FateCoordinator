using FateCoordinator.Model.Characters;
using FateCoordinator.Model.Games;
using FateCoordinator.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FateCoordinator.Data
{
    public class ApplicationDbContext : IdentityDbContext, IFateCoordinatorContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }

        public DbSet<GameCharacter> GameCharacters { get; set; }
        public DbSet<Game> Games { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}