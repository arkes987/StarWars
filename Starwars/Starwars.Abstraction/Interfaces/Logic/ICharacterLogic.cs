using Starwars.Data.Models.Character;
using System.Threading.Tasks;
using Starwars.Abstraction.Models.Paging;
using Starwars.Data.Extensions.Paging;

namespace Starwars.Abstraction.Interfaces.Logic
{
    public interface ICharacterLogic
    {
        Task<CharacterModel[]> GetAllCharacters();
        Task<PagedResult<CharacterModel>> GetCharactersPaged(int page, int pageSize);
        Task<CharacterModel> GetById(long characterId);
        Task<CharacterModel> SoftDeleteCharacter(long characterId);
        Task<CharacterModel> UpdateCharacter(CharacterModel character);
        Task<CharacterModel> AddCharacter(CharacterModel character);
    }
}
