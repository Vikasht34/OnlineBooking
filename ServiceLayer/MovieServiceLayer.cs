using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using PersistenceLayer;
using UtilityProject.Dto_Objects;
using UtilityProject.Genric_Mapper;

namespace ServiceLayer
{
    public class MovieServiceLayer : IMovieServiceLayer
    {
        private readonly IRepository _repository;

        public MovieServiceLayer(IRepository repository)
        {
            _repository = repository;
        }

        public bool BookMovie(BookingDto booking)
        {
            return _repository.BookMovie(booking);
        }

        public bool CheckSeatAvailbility(int movieId, int cinemaId, TimeSpan time)
        {
            return _repository.CheckSeatAvailbility(movieId, cinemaId, time);
        }

        public int GetAvailableSeaats(int movieId, int cinemaId, TimeSpan time)
        {
            return _repository.GetAvailableSeaats(movieId, cinemaId, time);
        }

        public List<MovieDto> GetMovies()
        {
            IEnumerable<Movie> movies = _repository.GetMovies();
            IEnumerable<MovieDto> movieDtos = GenericMapper.SimpleMapToList<Movie, MovieDto>(movies);
            return movieDtos.ToList();
        }

        public List<MovieShowDto> GetMovieShowByMovieId(int movieId)
        {
            IEnumerable<MovieShowDto> movieShows = _repository.GetMovieShowByMovieId(movieId);
            //IEnumerable<MovieShowDto> movieShowDtos =
            //    GenericMapper.SimpleMapToList<MovieShow, MovieShowDto>(movieShows);
            return movieShows.ToList();
        }
    }
}
