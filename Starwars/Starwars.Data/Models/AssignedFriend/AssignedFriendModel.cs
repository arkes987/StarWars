using Starwars.Data.Models.Character;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starwars.Data.Models.AssignedFriend
{
    [Table("assignedfriends")]
    public class AssignedFriendModel
    {
        public long CharacterId { get; set; }
        public long FriendId { get; set; }

        public CharacterModel Character { get; set; }
        public CharacterModel Friend { get; set; }
    }
}
