using FateCoordinator.Contracts;
using FateCoordinator.Model.Characters;
using FateCoordinator.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FateCoordinator.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IFateCoordinatorContext context;
        private readonly ILimiter limiter;

        public CharacterRepository(IFateCoordinatorContext context, ILimiter limiter)
        {
            this.context = context;
            this.limiter = limiter;
        }

        public async Task<CharacterDto> AddCharacterAsync(Guid userId, string name)
        {
            var character = new Character
            {
                UserId = userId
            };

            var dto = this.GetNewCharacter(character.Id, name);


            var limit = await this.limiter.GetCharacterLimitAsync();
            if ((await context.Characters.Where(x => x.UserId == userId).CountAsync()) >= limit)
            {
                throw new Exception($"Maximum limit of {limit} characters reached.");
            }

            character.Data = JsonConvert.SerializeObject(dto);

            await context.Characters.AddAsync(character);
            await context.SaveChangesAsync();

            return dto;
        }

        public async Task<Guid> CopyAsync(Guid userId, CharacterDto characterDto)
        {
            var character = new Character
            {
                UserId = userId
            };

            characterDto.Id = character.Id;
            characterDto.Name += " - copy";

            character.Data = JsonConvert.SerializeObject(characterDto);

            await context.Characters.AddAsync(character);
            await context.SaveChangesAsync();

            return character.Id;
        }

        public async Task DeleteCharacterAsync(Guid userId, Guid characterId)
        {
            var existingCharacter = await this.context.Characters.SingleAsync(x => x.Id == characterId && x.UserId == userId);

            this.context.Characters.Remove(existingCharacter);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CharacterDto>> GetAllAsync(Guid userId)
        {
            var characters = await this.context.Characters.Where(x => x.UserId == userId).ToListAsync();

            var dtos = new List<CharacterDto>();
            foreach (var character in characters)
            {
                var dto = JsonConvert.DeserializeObject<CharacterDto>(character.Data);
                if (dto == null)
                {
                    throw new ArgumentNullException(nameof(dto));
                }

                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<CharacterDto> GetCharacterAsync(Guid userId, Guid characterId)
        {
            var character = await this.context.Characters.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == characterId);

            if (character == null)
            {
                throw new ArgumentNullException($"No character of ID {characterId} exists for this user.");
            }

            var dto = JsonConvert.DeserializeObject<CharacterDto>(character.Data);
            return dto;
        }

        public async Task SaveCharacterAsync(Guid userId, CharacterDto character)
        {
            var existingCharacter = await this.context.Characters.SingleAsync(x => x.Id == character.Id && x.UserId == userId);

            existingCharacter.Data = JsonConvert.SerializeObject(character);

            await context.SaveChangesAsync();
        }

        private CharacterDto GetNewCharacter(Guid characterId, string name)
        {
            return new CharacterDto
            {
                Id = characterId,
                Name = name,
                Skills = Reference.GetDefaultSkills().ToDictionary(x => x, y => 0),
                Aspects = Enumerable.Repeat(string.Empty, 5).ToList(),
                Consequences = Reference.GetDefaultConsequences(),
                StressTracks = Reference.GetDefaultStressTracks(),
                Refresh = 3,
                FatePoints = 3
            };
        }
    }
}