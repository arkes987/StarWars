﻿using Starwars.Data.Attributes;
using Starwars.Data.Models.AssignedEpisode;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [NotPopulate]
        public int Status { get; set; }

        [Required]
        [NotPopulate]
        public DateTime SaveDate { get; set; }

        [NotPopulate]
        public DateTime? ModifyDate { get; set; }

        public ICollection<AssignedEpisodeModel> Episodes { get; set; }
        public ICollection<AssignedFriend.AssignedFriendModel> FriendTo { get; set; }
        public ICollection<AssignedFriend.AssignedFriendModel> Friends { get; set; }
    }
}
