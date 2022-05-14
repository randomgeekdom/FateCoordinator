namespace FateCoordinator.Contracts
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = "";
        public string Genre { get; set; } = "";
    }
}