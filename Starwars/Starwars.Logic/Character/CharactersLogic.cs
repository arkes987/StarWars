using System.Threading.Tasks;
using Starwars.Abstraction.Interfaces.Logic;
using Starwars.Data.Models.Character;

namespace Starwars.Logic.Character
{
    public class CharacterLogic : ICharacterLogic
    {
        public Task<CharacterModel> GetAllCharacters()
        {
            throw new System.NotImplementedException();
        }

        public Task<CharacterModel> GetById(long characterId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CharacterModel> SoftDeleteCharacter(long characterId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CharacterModel> UpdateCharacter(CharacterModel character)
        {
            throw new System.NotImplementedException();
        }

        public CharacterModel AddCharacter(CharacterModel character)
        {
            throw new System.NotImplementedException();
        }
    }
}
