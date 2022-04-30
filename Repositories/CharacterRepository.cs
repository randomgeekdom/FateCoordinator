using AutoMapper;
using FateCoordinator.Model.Characters;
using Microsoft.EntityFrameworkCore;

namespace FateCoordinator.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IFateCoordinatorContext context;
        private readonly IMapper mapper;

        public CharacterRepository(IFateCoordinatorContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CharacterDto> AddCharacterAsync(Guid userId, string name)
        {
            var character = new Character
            {
                UserId = userId,
                Name = name
            };
            await context.Characters.AddAsync(character);
            await context.SaveChangesAsync();

            return mapper.Map<CharacterDto>(character);
        }

        public async Task<IEnumerable<CharacterDto>> GetAllAsync(Guid userId)
        {
            var characters = await this.context.Characters.Where(x => x.UserId == userId).ToListAsync();
            return mapper.Map<IEnumerable<CharacterDto>>(characters);
        }
    }
}