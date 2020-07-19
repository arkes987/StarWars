using Microsoft.VisualStudio.TestTools.UnitTesting;
using Starwars.Logic.Character;

namespace Starwars.Tests.Character
{
    [TestClass]
    public class CharacterLogicTests
    {
        [TestMethod]
        public void GetAllCharacters_CheckCharacterRecords_ReturnsValidRecords()
        {
            var subject = new CharacterLogic(null);


        }

        [TestMethod]
        public void GetAllCharacters_CheckEpisodesRecords_ProperlyJoinEpisodes()
        {

        }


        [TestMethod]
        public void GetAllCharacters_CheckFriendRecords_ProperlyJoinFriends()
        {

        }

        [TestMethod]
        public void GetById_ChecksRecord_ProperlyReturnsCharacterRecord()
        {

        }

        [TestMethod]
        public void SoftDeleteCharacter_ChecksSaveChanges_ProperlyCallingSaveChangesOnDb()
        {
            //sprawdza czy na db zostalo wywolane savechanges dokladnie jeden raz
        }

        [TestMethod]
        public void SoftDeleteCharacter_CheckUpdatesStatus_ProperlySetsDeletedStatusOnRecord()
        {
            //sprawdza czy status rekordu został zaktualizowany na usunięty
        }

        [TestMethod]
        public void UpdateCharacter_CheckModifiesRecord_ValidRecordExistInCollection()
        {
            //sprawdzamy czy SaveChanges zostało prawidłowo wywołane na db dokładnie jeden raz
        }

        [TestMethod]
        public void UpdateCharacter_ChecksSaveChanges_ProperlyCallingSaveChangesOnDb()
        {
            //sprawdzamy czy SaveChanges zostało prawidłowo wywołane na db dokładnie jeden raz
        }

        [TestMethod]
        public void AddCharacter_CheckAddsRecord_ProperlyAddsRecordToCollection()
        {
            //sprawdzamy czy rekord istnieje w kolekcji Characters
        }

        [TestMethod]
        public void AddCharacter_CheckCallsAdd_ProperlyCallingAddOnCollection()
        {
            //sprawdzamy czy na kolekcji Characters zostało prawidłowo wywołane Add jeden raz
        }

        [TestMethod]
        public void AddCharacter_ChecksSaveChanges_ProperlyCallingSaveChangesOnDb()
        {
            //sprawdzamy czy SaveChanges zostało prawidłowo wywołane na db dokładnie jeden raz
        }
    }
}