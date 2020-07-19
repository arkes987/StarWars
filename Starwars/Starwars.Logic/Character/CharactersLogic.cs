using Microsoft.EntityFrameworkCore;
using Starwars.Abstraction.Enums;
using Starwars.Abstraction.Interfaces.Logic;
using Starwars.Data;
using Starwars.Data.Extensions.Character;
using Starwars.Data.Models.Character;
using System;
using System.Linq;
using System.Threading.Tasks;
using Starwars.Data.Extensions.Paging;

namespace Starwars.Logic.Character
{
    public class CharacterLogic : ICharacterLogic
    {
        private readonly IStarwarsContext _starwarsContext;
        public CharacterLogic(IStarwarsContext starwarsContext)
        {
            _starwarsContext = starwarsContext;
        }
        public async Task<CharacterModel[]> GetAllCharacters()
        {
            IQueryable<CharacterModel> activeCharacters = _starwarsContext.Characters
                .Include(x => x.Episodes).ThenInclude(y => y.Episode).Include(x => x.Friends).Where(character =>
                    character.Status != (int) CharacterStatusEnum.DELETED);

            return await activeCharacters.ToArrayAsync();
        }
        public async Task<PagedResult<CharacterModel>> GetCharactersPaged(int page, int pageSize)
        {
            return await _starwarsContext.Characters.Include(x => x.Episodes).ThenInclude(y => y.Episode)
                .Include(x => x.Friends).Where(character => character.Status != (int) CharacterStatusEnum.DELETED)
                .GetPagedAsync(page, pageSize);
        }
        public async Task<CharacterModel> GetById(long characterId)
        {
            var character = await _starwarsContext.Characters.FirstOrDefaultAsync(x =>
                x.Id == characterId && x.Status != (int)CharacterStatusEnum.DELETED);

            return character;
        }
        public async Task<CharacterModel> SoftDeleteCharacter(long characterId)
        {
            var character = await _starwarsContext.Characters.FirstOrDefaultAsync(x => x.Id == characterId);

            if (character != null)
            {
                character.Status = (int)CharacterStatusEnum.DELETED;
                character.ModifyDate = DateTime.Now;
                await _starwarsContext.SaveChangesAsync();

                return character;
            }

            return null;
        }
        public async Task<CharacterModel> UpdateCharacter(CharacterModel character)
        {
            var existingCharacter = await _starwarsContext.Characters.FirstOrDefaultAsync(x => x.Id == character.Id);

            if (existingCharacter == null)
                return null;

            //here need to populate changes to existing object and only savechanges because of EF tracking

            existingCharacter.PopulateOnModel(character);
            existingCharacter.ModifyDate = DateTime.Now;
            await _starwarsContext.SaveChangesAsync();

            return character;
        }
        public async Task<CharacterModel> AddCharacter(CharacterModel character)
        {
            character.SaveDate = DateTime.Now;
            character.Status = (int)CharacterStatusEnum.ACTIVE;

            _starwarsContext.Characters.Add(character);

            await _starwarsContext.SaveChangesAsync();

            return character;
        }
    }
}
