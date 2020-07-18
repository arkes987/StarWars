using Microsoft.EntityFrameworkCore;
using Starwars.Data.Models.AssignedEpisode;
using Starwars.Data.Models.AssignedFriend;
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
            base.OnModelCreating(modelBuilder);

            //composite key
            modelBuilder.Entity<AssignedEpisodeModel>().HasKey(key => new
            {
                key.CharacterId,
                key.EpisodeId
            });

            //composite key
            modelBuilder.Entity<AssignedFriendModel>().HasKey(key => new
            {
                key.CharacterId,
                key.FriendId
            });

            modelBuilder.Entity<AssignedFriendModel>().HasOne(x => x.Character).WithMany(x => x.FriendTo)
                .HasForeignKey(x => x.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AssignedFriendModel>().HasOne(x => x.Friend).WithMany(x => x.Friends)
                .HasForeignKey(x => x.CharacterId)
                .OnDelete(DeleteBehavior.Restrict);

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
