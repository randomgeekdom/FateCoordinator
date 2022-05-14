using System.ComponentModel.DataAnnotations;

namespace FateCoordinator.Model.Games
{
    public class Game : UserEntity
    {
        public string Data { get; set; } = string.Empty;
    }
}