using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Starwars.Abstraction.Dto.Character;
using Starwars.Controllers.Mappings.Character;
using Starwars.Data.Models.AssignedEpisode;
using Starwars.Data.Models.AssignedFriend;
using Starwars.Data.Models.Character;
using Starwars.Data.Models.Episode;

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
        public void ToCharacterDto_ChecksProperties_ProperlyMapsModelToResponseDto()
        {
            var testSubject = GetTestSubject();

            var characterModel = new CharacterModel
            {
                Name = "Luke Skywalker",
                Planet = "Alderaan",
                Episodes = new List<AssignedEpisodeModel>
                {
                    new AssignedEpisodeModel
                    {
                        Episode = new EpisodeModel
                        {
                            Name = "NEWHOPE"
                        }
                    }
                },
                Friends = new List<AssignedFriendModel>
                {
                    new AssignedFriendModel
                    {
                        Character = new CharacterModel
                        {
                            Name = "Wilhuff Tarkin"
                        }
                    }
                }

            };

            var dto = testSubject.ToCharacterResponseDto(characterModel);

            Assert.AreEqual(characterModel.Name, dto.Name);
            Assert.AreEqual(characterModel.Planet, dto.Planet);
            Assert.AreEqual(characterModel.Episodes.ElementAt(0).Episode.Name, "NEWHOPE");
            Assert.AreEqual(characterModel.Friends.ElementAt(0).Character.Name, "Wilhuff Tarkin");
        }

        [TestMethod]
        public void ToCharacterModel_ChecksProperties_ProperlyMapsDtoToModel()
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

        [TestMethod]
        public void PopulateIdOnModel_ChecksId_ProperlyUpdatesModel()
        {
            var testSubject = GetTestSubject();

            const int idToPopulate = 1;

            var characterModel = new CharacterModel
            {
                Id = 0
            };

            testSubject.PopulateIdOnModel(idToPopulate, characterModel);

            Assert.IsTrue(characterModel.Id == idToPopulate);
        }
    }
}
