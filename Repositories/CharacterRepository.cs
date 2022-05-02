using FateCoordinator.Contracts;
using FateCoordinator.Model.Characters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FateCoordinator.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IFateCoordinatorContext context;

        public CharacterRepository(IFateCoordinatorContext context)
        {
            this.context = context;
        }

        public async Task<CharacterDto> AddCharacterAsync(Guid userId, string name)
        {
            var character = new Character
            {
                UserId = userId
            };

            var dto = this.GetNewCharacter(character.Id, name);

            character.Data = JsonConvert.SerializeObject(dto);

            await context.Characters.AddAsync(character);
            await context.SaveChangesAsync();

            return dto;
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
                Skills = Skills.GetAll().ToDictionary(x => x, y => 0),
                Aspects = Enumerable.Repeat(string.Empty, 5).ToList(),
                Consequences = new List<Consequence>
                {
                    new Consequence{
                        Condition = string.Empty,
                        Level = 2
                    },

                    new Consequence{
                        Condition = string.Empty,
                        Level = 4
                    },

                    new Consequence{
                        Condition = string.Empty,
                        Level = 6
                    }
                },
                StressTracks = new List<StressTrack>
                {
                    new StressTrack
                    {
                        Name = "Physical Stress",
                        Skill = Skills.Physique,
                        Stress = new Dictionary<int, bool>
                        {
                            { 1, false },
                            { 2, false },
                        }
                    },

                    new StressTrack
                    {
                        Name = "Mental Stress",
                        Skill = Skills.Will,
                        Stress = new Dictionary<int, bool>
                        {
                            { 1, false },
                            { 2, false },
                        }
                    }
                },
                Refresh = 3,
                FatePoints = 3
            };
        }
    }
}