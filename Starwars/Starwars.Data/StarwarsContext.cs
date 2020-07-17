using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Starwars.Data
{
    public interface IStarwarsContext
    {

    }

    public class StarwarsContext : DbContext, IStarwarsContext
    {
        public StarwarsContext(DbContextOptions<StarwarsContext> options) : base(options)
        {
            
        }
        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
