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

            var dtos = new List<CharacterDto>();
            foreach (var character in characters)
            {
                var dto = mapper.Map<CharacterDto>(character);
                dto.Aspects = await this.context.CharacterAspects.Where(x => x.CharacterId == character.Id && x.UserId == userId)
                                                                 .OrderBy(x => x.AspectType)
                                                                 .Select(x => x.Name)
                                                                 .ToListAsync();
                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<CharacterDto?> GetCharacterAsync(Guid userId, Guid characterId)
        {
            var character = await this.context.Characters.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == characterId);

            if(character == null)
            {
                return null;
            }

            var dto = mapper.Map<CharacterDto>(character);
            dto.Aspects = await this.context.CharacterAspects.Where(x => x.CharacterId == character.Id && x.UserId == userId)
                                                             .OrderBy(x => x.AspectType)
                                                             .Select(x => x.Name)
                                                             .ToListAsync();
            return dto;
        }
    }
}