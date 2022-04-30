using System.ComponentModel.DataAnnotations;

namespace FateCoordinator.Model.Games
{
    public class Game : UserEntity
    {
        public string? Genre { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = "New Game";
    }
}