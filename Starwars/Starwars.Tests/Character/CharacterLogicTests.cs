using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockQueryable.Moq;
using Moq;
using Starwars.Abstraction.Enums;
using Starwars.Data;
using Starwars.Data.Models.AssignedEpisode;
using Starwars.Data.Models.AssignedFriend;
using Starwars.Data.Models.Character;
using Starwars.Logic.Character;

namespace Starwars.Tests.Character
{
    [TestClass]
    public class CharacterLogicTests
    {
        private readonly Mock<IStarwarsContext> _starwarsContextMock = new Mock<IStarwarsContext>();

        private CharacterLogic GetTestSubject()
        {
            return new CharacterLogic(_starwarsContextMock.Object);
        }

        [TestMethod]
        public async Task GetAllCharacters_CheckCharacterRecords_ReturnsValidRecords()
        {
            var characterLogic = GetTestSubject();

            var characterList = new List<CharacterModel>
            {
                new CharacterModel
                {
                    Id = 0,
                    Name = "Luke Skywalker",
                    Planet = "Alderaan",
                    Status = (int)CharacterStatusEnum.ACTIVE
                },
                new CharacterModel
                {
                    Id = 1,
                    Name = "C-3PO",
                    Planet = "Kamino",
                    Status = (int)CharacterStatusEnum.ACTIVE
                }
            };

            var charactersMock = characterList.AsQueryable().BuildMockDbSet();

            _starwarsContextMock.Setup(x => x.Characters).Returns(charactersMock.Object);

            var characters = await characterLogic.GetAllCharacters();

            CollectionAssert.AreEqual(characterList, characters);
        }

        [TestMethod]
        public async Task GetAllCharacters_CheckSkipsDeletedRecords_ReturnsValidRecordCount()
        {
            var characterLogic = GetTestSubject();

            var characterList = new List<CharacterModel>
            {
                new CharacterModel
                {
                    Id = 0,
                    Name = "Luke Skywalker",
                    Planet = "Alderaan",
                    Status = (int)CharacterStatusEnum.ACTIVE
                },
                new CharacterModel
                {
                    Id = 1,
                    Name = "C-3PO",
                    Planet = "Kamino",
                    Status = (int)CharacterStatusEnum.DELETED
                }
            };

            var charactersMock = characterList.AsQueryable().BuildMockDbSet();

            _starwarsContextMock.Setup(x => x.Characters).Returns(charactersMock.Object);

            var characters = await characterLogic.GetAllCharacters();

            Assert.AreEqual(1, characters.Length);
        }

        [TestMethod]
        public async Task GetAllCharacters_CheckEpisodesRecords_ProperlyJoinEpisodes()
        {
            var characterLogic = GetTestSubject();

            var characterList = new List<CharacterModel>
            {
                new CharacterModel
                {
                    Id = 0,
                    Name = "Luke Skywalker",
                    Planet = "Alderaan",
                    Status = (int)CharacterStatusEnum.ACTIVE,
                    Episodes = new List<AssignedEpisodeModel>
                    {
                        new AssignedEpisodeModel
                        {
                            CharacterId = 0,
                            EpisodeId = 0,
                            Episode = new Data.Models.Episode.EpisodeModel
                            {
                                Id = 0,
                                Name = "NEWHOPE",
                                Status = 1
                            }
                        },
                        new AssignedEpisodeModel
                        {
                            CharacterId = 0,
                            EpisodeId = 1,
                            Episode = new Data.Models.Episode.EpisodeModel
                            {
                                Id = 1,
                                Name = "EMPIRE",
                                Status = 1
                            }
                        }
                    }
                }
            };

            var charactersMock = characterList.AsQueryable().BuildMockDbSet();

            _starwarsContextMock.Setup(x => x.Characters).Returns(charactersMock.Object);

            var characters = await characterLogic.GetAllCharacters();

            CollectionAssert.AreEqual(characterList.ElementAt(0).Episodes.ToList(), characters.ElementAt(0).Episodes.ToList());
        }

        [TestMethod]
        public async Task GetAllCharacters_CheckFriendRecords_ProperlyJoinFriends()
        {
            var characterLogic = GetTestSubject();

            var characterList = new List<CharacterModel>
            {
                new CharacterModel
                {
                    Id = 0,
                    Name = "Luke Skywalker",
                    Planet = "Alderaan",
                    Status = (int)CharacterStatusEnum.ACTIVE,
                    Friends = new List<AssignedFriendModel>
                    {
                        new AssignedFriendModel
                        {
                            Friend = new CharacterModel
                            {
                                Id = 0,
                                Name = "Darth Vader",
                                Planet = "Alderaan"
                            }
                        },
                        new AssignedFriendModel
                        {
                            Friend = new CharacterModel
                            {
                                Id = 1,
                                Name = "Darth Vader",
                                Planet = "Han Solo"
                            }
                        }
                    }
                }
            };

            var charactersMock = characterList.AsQueryable().BuildMockDbSet();

            _starwarsContextMock.Setup(x => x.Characters).Returns(charactersMock.Object);

            var characters = await characterLogic.GetAllCharacters();

            CollectionAssert.AreEqual(characterList.ElementAt(0).Friends.ToList(), characters.ElementAt(0).Friends.ToList());
        }

        [TestMethod]
        public async Task GetById_ChecksRecord_ProperlyReturnsCharacterRecord()
        {
            var characterLogic = GetTestSubject();

            var characterList = new List<CharacterModel>
            {
                new CharacterModel
                {
                    Id = 0,
                    Name = "Luke Skywalker",
                    Planet = "Alderaan",
                    Status = (int)CharacterStatusEnum.ACTIVE,
                }
            };

            var charactersMock = characterList.AsQueryable().BuildMockDbSet();

            _starwarsContextMock.Setup(x => x.Characters).Returns(charactersMock.Object);

            var character = await characterLogic.GetById(0);

            Assert.AreEqual(characterList[0], character);
        }

        [TestMethod]
        public async Task GetById_ChecksRecord_ReturnsNullWhenRecordNotFound()
        {
            var characterLogic = GetTestSubject();

            var characterList = new List<CharacterModel>
            {
                new CharacterModel
                {
                    Id = 0,
                    Name = "Luke Skywalker",
                    Planet = "Alderaan",
                    Status = (int)CharacterStatusEnum.ACTIVE,
                }
            };

            var charactersMock = characterList.AsQueryable().BuildMockDbSet();

            _starwarsContextMock.Setup(x => x.Characters).Returns(charactersMock.Object);

            var character = await characterLogic.GetById(1);

            Assert.AreEqual(null, character);
        }

        [TestMethod]
        public async Task SoftDeleteCharacter_ChecksSaveChanges_ProperlyCallingSaveChangesOnDb()
        {
            var characterLogic = GetTestSubject();

            var characterList = new List<CharacterModel>
            {
                new CharacterModel
                {
                    Id = 0,
                    Name = "Luke Skywalker",
                    Planet = "Alderaan",
                    Status = (int)CharacterStatusEnum.ACTIVE,
                }
            };

            var charactersMock = characterList.AsQueryable().BuildMockDbSet();

            _starwarsContextMock.Setup(x => x.Characters).Returns(charactersMock.Object);

            await characterLogic.SoftDeleteCharacter(0);

            _starwarsContextMock.Verify(mock => mock.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task SoftDeleteCharacter_CheckUpdatesStatus_ProperlySetsDeletedStatusOnRecord()
        {
            var characterLogic = GetTestSubject();

            var characterList = new List<CharacterModel>
            {
                new CharacterModel
                {
                    Id = 0,
                    Name = "Luke Skywalker",
                    Planet = "Alderaan",
                    Status = (int)CharacterStatusEnum.ACTIVE,
                }
            };

            var charactersMock = characterList.AsQueryable().BuildMockDbSet();

            _starwarsContextMock.Setup(x => x.Characters).Returns(charactersMock.Object);

            var character = await characterLogic.SoftDeleteCharacter(0);

            Assert.AreEqual((int)CharacterStatusEnum.DELETED, character.Status);
        }

        [TestMethod]
        public async Task UpdateCharacter_CheckModifiesRecord_ValidRecordExistInCollection()
        {
            var characterLogic = GetTestSubject();

            var characterList = new List<CharacterModel>
            {
                new CharacterModel
                {
                    Id = 0,
                    Name = "Luke Skywalker",
                    Planet = "Alderaan",
                    Status = (int)CharacterStatusEnum.ACTIVE,
                }
            };

            var charactersMock = characterList.AsQueryable().BuildMockDbSet();

            _starwarsContextMock.Setup(x => x.Characters).Returns(charactersMock.Object);

            var characterChangedModel = new CharacterModel
            {
                Id = 0,
                Name = "LukeSky",
                Planet = "Alderan",
                Status = (int)CharacterStatusEnum.ACTIVE
            };

            await characterLogic.UpdateCharacter(characterChangedModel);

            Assert.AreEqual("LukeSky", characterList[0].Name);
            Assert.AreEqual("Alderan", characterList[0].Planet);
        }

        [TestMethod]
        public async Task UpdateCharacter_ChecksSaveChanges_ProperlyCallingSaveChangesOnDb()
        {
            var characterLogic = GetTestSubject();

            var characterList = new List<CharacterModel>
            {
                new CharacterModel
                {
                    Id = 0,
                    Name = "Luke Skywalker",
                    Planet = "Alderaan",
                    Status = (int)CharacterStatusEnum.ACTIVE,
                }
            };

            var charactersMock = characterList.AsQueryable().BuildMockDbSet();

            _starwarsContextMock.Setup(x => x.Characters).Returns(charactersMock.Object);

            var characterChangedModel = new CharacterModel
            {
                Id = 0,
                Name = "LukeSky",
                Planet = "Alderan",
                Status = (int)CharacterStatusEnum.ACTIVE
            };

            await characterLogic.UpdateCharacter(characterChangedModel);

            _starwarsContextMock.Verify(mock => mock.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task AddCharacter_CheckAddsRecord_ProperlyAddsRecordToCollection()
        {
            var characterLogic = GetTestSubject();

            var characterList = new List<CharacterModel>
            {
                new CharacterModel
                {
                    Id = 0,
                    Name = "Luke Skywalker",
                    Planet = "Alderaan",
                    Status = (int)CharacterStatusEnum.ACTIVE,
                }
            };

            var charactersMock = characterList.AsQueryable().BuildMockDbSet();

            _starwarsContextMock.Setup(x => x.Characters).Returns(charactersMock.Object);

            var newCharacterModel = new CharacterModel
            {
                Name = "Darth Vader",
                Planet = "Alderaan",
                Status = (int)CharacterStatusEnum.ACTIVE
            };

            var addedResult = await characterLogic.AddCharacter(newCharacterModel);

            Assert.AreEqual(newCharacterModel, addedResult);
        }

        [TestMethod]
        public async Task AddCharacter_CheckCallsAdd_ProperlyCallingAddOnCollection()
        {
            var characterLogic = GetTestSubject();

            var characterList = new List<CharacterModel>
            {
                new CharacterModel
                {
                    Id = 0,
                    Name = "Luke Skywalker",
                    Planet = "Alderaan",
                    Status = (int)CharacterStatusEnum.ACTIVE,
                }
            };

            var charactersMock = characterList.AsQueryable().BuildMockDbSet();

            _starwarsContextMock.Setup(x => x.Characters).Returns(charactersMock.Object);

            var newCharacterModel = new CharacterModel
            {
                Name = "Darth Vader",
                Planet = "Alderaan",
                Status = (int)CharacterStatusEnum.ACTIVE
            };

            await characterLogic.AddCharacter(newCharacterModel);

            charactersMock.Verify(mock => mock.Add(newCharacterModel), Times.Once);
        }

        [TestMethod]
        public async Task AddCharacter_ChecksSaveChanges_ProperlyCallingSaveChangesOnDb()
        {
            var characterLogic = GetTestSubject();

            var characterList = new List<CharacterModel>
            {
                new CharacterModel
                {
                    Id = 0,
                    Name = "Luke Skywalker",
                    Planet = "Alderaan",
                    Status = (int)CharacterStatusEnum.ACTIVE,
                }
            };

            var charactersMock = characterList.AsQueryable().BuildMockDbSet();

            _starwarsContextMock.Setup(x => x.Characters).Returns(charactersMock.Object);

            var newCharacterModel = new CharacterModel
            {
                Name = "Darth Vader",
                Planet = "Alderaan",
                Status = (int)CharacterStatusEnum.ACTIVE
            };

            await characterLogic.AddCharacter(newCharacterModel);

            _starwarsContextMock.Verify(mock => mock.SaveChangesAsync(), Times.Once);
        }
    }
}