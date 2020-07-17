using System;
using Starwars.Data.Models.Episode;
using System.Collections.Generic;

namespace Starwars.Data.Models.Character
{
    public class CharacterModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Planet { get; set; }
        public IList<CharacterModel> Friends { get; set; }
        public IList<EpisodeModel> Episodes { get; set; }
        public int Status { get; set; }
        public DateTime SaveDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
