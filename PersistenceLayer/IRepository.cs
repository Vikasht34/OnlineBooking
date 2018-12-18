using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using UtilityProject.Dto_Objects;

namespace PersistenceLayer
{
   public interface IRepository
   {
       IEnumerable<Movie> GetMovies();

       bool CheckSeatAvailbility(int movieId, int cinemaId, TimeSpan time);

       int GetAvailableSeaats(int movieId, int cinemaId, TimeSpan time);

       bool BookMovie(BookingDto booking);

       IEnumerable<MovieShowDto> GetMovieShowByMovieId(int movieId);




   }
}
