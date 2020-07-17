using Microsoft.EntityFrameworkCore;
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

        //#region Required

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}

        //#endregion

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
