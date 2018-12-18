using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.CustomDbContext
{
    public class MovieContext : MovieEntities, IMovieContext
    {
        public MovieContext()
        {
            Database.SetInitializer<MovieEntities>(null);
        }

        public DbContext GetDbContext()
        {
            return (DbContext) this;
        }

    }
}
