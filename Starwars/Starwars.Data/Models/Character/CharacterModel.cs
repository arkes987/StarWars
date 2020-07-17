using System;
using Starwars.Data.Models.Episode;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starwars.Data.Models.Character
{
    [Table("characters")]
    public class CharacterModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public string Planet { get; set; }

        public ICollection<EpisodeModel> Episodes { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public DateTime SaveDate { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
