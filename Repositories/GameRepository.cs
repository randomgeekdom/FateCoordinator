using FateCoordinator.Contracts;
using FateCoordinator.Model.Games;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FateCoordinator.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly IFateCoordinatorContext context;

        public GameRepository(IFateCoordinatorContext context)
        {
            this.context = context;
        }

        public async Task<GameDto> AddAsync(Guid userId, string name)
        {
            var game = new Game
            {
                UserId = userId
            };

            var dto = new GameDto
            {
                Id = game.Id,
                Name = name
            };

            game.Data = JsonConvert.SerializeObject(dto);

            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();

            return dto;
        }

        public async Task DeleteAsync(Guid userId, Guid gameId)
        {
            var existing = await this.context.Games.SingleAsync(x => x.Id == gameId && x.UserId == userId);

            this.context.Games.Remove(existing);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GameDto>> GetAllAsync(Guid userId)
        {
            var games = await this.context.Games.Where(x => x.UserId == userId).ToListAsync();

            var dtos = new List<GameDto>();
            foreach (var game in games)
            {
                var dto = JsonConvert.DeserializeObject<GameDto>(game.Data);
                if (dto == null)
                {
                    throw new ArgumentNullException(nameof(dto));
                }

                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<GameDto> GetAsync(Guid userId, Guid gameId)
        {
            var game = await this.context.Games.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == gameId);

            if (game == null)
            {
                throw new ArgumentNullException($"No game of ID {gameId} exists for this user.");
            }

            var dto = JsonConvert.DeserializeObject<GameDto>(game.Data);
            return dto;
        }

        public async Task SaveAsync(Guid userId, GameDto game)
        {
            var existingGame = await this.context.Games.SingleAsync(x => x.Id == game.Id && x.UserId == userId);

            existingGame.Data = JsonConvert.SerializeObject(game);

            await context.SaveChangesAsync();
        }
    }
}
