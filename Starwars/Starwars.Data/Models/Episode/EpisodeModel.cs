using System;

namespace Starwars.Data.Models.Episode
{
    public class EpisodeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime SaveDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
