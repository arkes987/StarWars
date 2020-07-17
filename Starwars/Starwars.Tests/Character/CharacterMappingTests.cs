using Microsoft.VisualStudio.TestTools.UnitTesting;
using Starwars.Abstraction.Dto.Character;
using Starwars.Controllers.Mappings.Character;
using Starwars.Data.Models.Character;

namespace Starwars.Tests.Character
{
    [TestClass]
    public class CharacterMappingTests
    {
        private CharacterMapping GetTestSubject()
        {
            return new CharacterMapping();
        }

        [TestMethod]
        public void ToCharacterDto()
        {
            var testSubject = GetTestSubject();

            var characterModel = new CharacterModel
            {

            };

            var dto = testSubject.ToCharacterResponseDto(characterModel);

            //Assert.AreEqual(characterModel.Id, dto);

        }

        [TestMethod]
        public void ToCharacterModel()
        {
            var testSubject = GetTestSubject();

            var characterDto = new CharacterDto
            {

            };

            var model = testSubject.ToCharacterModel(characterDto);
        }
    }
}
