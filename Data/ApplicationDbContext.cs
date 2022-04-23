using FateCoordinator.Model.Characters;
using FateCoordinator.Model.Games;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FateCoordinator.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CharacterAspect> CharacterAspects { get; set; }
        public DbSet<CharacterConsequence> CharacterConsequences { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }
        public DbSet<CharacterStressTrack> CharacterStressTracks { get; set; }
        public DbSet<GameCharacter> GameCharacters { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}