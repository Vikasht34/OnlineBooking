using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.CustomDbContext
{
   public interface IMovieContext
   {
       DbContext GetDbContext();
       int SaveChanges();
       DbSet<Movie> Movies { get; set; }
       DbSet<User> Users { get; set; }
       DbSet<Cinema> Cinemas { get; set; }
       DbSet<MovieShow> MovieShows { get; set; }
       DbSet<Booking> Bookings { get; set; }
   }
}
