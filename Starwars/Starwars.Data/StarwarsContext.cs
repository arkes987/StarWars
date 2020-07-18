using Microsoft.EntityFrameworkCore;
using Starwars.Data.Models.AssignedEpisode;
using Starwars.Data.Models.Character;
using Starwars.Data.Models.Episode;

namespace Starwars.Data
{
    public interface IStarwarsContext
    {
        DbSet<CharacterModel> Characters { get; set; }
        DbSet<EpisodeModel> Episodes { get; set; }
        void SaveChanges();
    }

    public class StarwarsContext : DbContext, IStarwarsContext
    {
        public StarwarsContext(DbContextOptions<StarwarsContext> options) : base(options)
        {

        }

        public DbSet<CharacterModel> Characters { get; set; }
        public DbSet<EpisodeModel> Episodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //composite key
            modelBuilder.Entity<AssignedEpisodeModel>().HasKey(key => new
            {
                key.CharacterId,
                key.EpisodeId
            });

            modelBuilder.Entity<AssignedEpisodeModel>().HasOne(character => character.Character)
                .WithMany(episode => episode.Episodes).HasForeignKey(key => key.CharacterId);

            modelBuilder.Entity<AssignedEpisodeModel>().HasOne(episode => episode.Episode)
                .WithMany(character => character.Characters).HasForeignKey(key => key.EpisodeId);
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
