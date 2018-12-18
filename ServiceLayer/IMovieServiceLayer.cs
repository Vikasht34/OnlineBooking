using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityProject.Dto_Objects;

namespace ServiceLayer
{
   public interface IMovieServiceLayer
    {
        List<MovieDto> GetMovies();

        bool CheckSeatAvailbility(int movieId, int cinemaId, TimeSpan time);

        int GetAvailableSeaats(int movieId, int cinemaId, TimeSpan time);

        bool BookMovie(BookingDto booking);
        List<MovieShowDto> GetMovieShowByMovieId(int movieId);

    }
}
