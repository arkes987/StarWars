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
                Name = "Luke Skywalker",
                Planet = "Alderaan"
            };

            var dto = testSubject.ToCharacterResponseDto(characterModel);

            Assert.AreEqual(characterModel.Name, dto.Name);
            Assert.AreEqual(characterModel.Planet, dto.Planet);
        }

        [TestMethod]
        public void ToCharacterModel()
        {
            var testSubject = GetTestSubject();

            var characterDto = new CharacterDto
            {
                Name = "Luke Skywalker",
                Planet = "Alderaan"
            };

            var model = testSubject.ToCharacterModel(characterDto);

            Assert.AreEqual(characterDto.Name, model.Name);
            Assert.AreEqual(characterDto.Planet, model.Planet);
        }
    }
}
