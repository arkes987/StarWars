using System.ComponentModel.DataAnnotations.Schema;
using Starwars.Data.Models.Character;
using Starwars.Data.Models.Episode;

namespace Starwars.Data.Models.AssignedEpisode
{
    [Table("assignedepisodes")]
    public class AssignedEpisodeModel
    {
        public long CharacterId { get; set; }
        public long EpisodeId { get; set; }

        public CharacterModel Character { get; set; }
        public EpisodeModel Episode { get; set; }
    }
}
