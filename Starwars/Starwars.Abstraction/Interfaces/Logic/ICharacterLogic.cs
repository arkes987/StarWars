using Starwars.Data.Models.Character;
using System.Threading.Tasks;

namespace Starwars.Abstraction.Interfaces.Logic
{
    public interface ICharacterLogic
    {
        Task<CharacterModel[]> GetAllCharacters();
        Task<CharacterModel> GetById(long characterId);
        Task<CharacterModel> SoftDeleteCharacter(long characterId);
        Task<CharacterModel> UpdateCharacter(long characterId, CharacterModel character);
        CharacterModel AddCharacter(CharacterModel character);
    }
}
