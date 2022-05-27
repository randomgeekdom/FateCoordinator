namespace FateCoordinator.Model.Games
{
    public class GameCharacter : UserEntity
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }

        public Guid CharacterId { get; set; }
    }
}