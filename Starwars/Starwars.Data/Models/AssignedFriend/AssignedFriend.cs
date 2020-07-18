using System.ComponentModel.DataAnnotations.Schema;
using Starwars.Data.Models.Character;

namespace Starwars.Data.Models.AssignedFriend
{
    [Table("assignedfriends")]
    public class AssignedFriend
    {
        public long CharacterId { get; set; }
        public long FriendId { get; set; }

        public CharacterModel Character { get; set; }
        public CharacterModel Friend { get; set; }
    }
}
