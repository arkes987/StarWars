using System;
using Starwars.Data.Models.Episode;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Starwars.Data.Attributes;

namespace Starwars.Data.Models.Character
{
    [Table("characters")]
    public class CharacterModel
    {
        [Key]
        [NotPopulate]
        public long Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public string Planet { get; set; }

        public ICollection<EpisodeModel> Episodes { get; set; }

        [Required]
        [NotPopulate]
        public int Status { get; set; }

        [Required]
        [NotPopulate]
        public DateTime SaveDate { get; set; }

        [NotPopulate]
        public DateTime? ModifyDate { get; set; }
    }
}
