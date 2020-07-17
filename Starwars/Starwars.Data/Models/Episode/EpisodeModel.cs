using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starwars.Data.Models.Episode
{
    [Table("episodes")]
    public class EpisodeModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public DateTime SaveDate { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
