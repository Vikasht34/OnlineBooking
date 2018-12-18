using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.CustomDbContext;
using UtilityProject.Dto_Objects;
using UtilityProject.Genric_Mapper;

namespace PersistenceLayer
{
    public class Repository : IRepository
    {
        private readonly IMovieContext _movieContext;

        public Repository(IMovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public bool BookMovie(BookingDto booking)
        {
            bool success = false;

            if (CheckSeatAvailbility(booking.MovieId, booking.CinemaId, booking.MovieTime))
            {
                try
                {
                    Booking bookObj = GenericMapper.SimpleMap<BookingDto, Booking>(booking);
                    _movieContext.Bookings.Add(bookObj);
                    success = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            
            return success;
        }

        public bool CheckSeatAvailbility(int movieId, int cinemaId, TimeSpan time)
        {
            if (GetAvailableSeaats(movieId,cinemaId,time) > 0) return true;
            return false;
        }

        public int GetAvailableSeaats(int movieId, int cinemaId, TimeSpan time)
        {
            int rowSeats = GetToalSeatsPerCinema(cinemaId);

            int? bookedSeats = _movieContext.Bookings
                .FirstOrDefault(x => x.MovieId == movieId && x.CinemaId == cinemaId && x.MovieTime == time)?.Seats;
            int remainingSeats = rowSeats;
            if (bookedSeats.HasValue)
            {
                remainingSeats = rowSeats - bookedSeats.Value;
            }

            return remainingSeats;

        }

        private int GetToalSeatsPerCinema(int cinemaId)
        {
            int? getTotalSeats = 0;
            try
            {
                getTotalSeats = _movieContext.Cinemas.FirstOrDefault(x => x.Id == cinemaId)?.Seats;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

           return getTotalSeats.Value;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _movieContext.Movies.ToList();

        }

        public IEnumerable<MovieShowDto> GetMovieShowByMovieId(int movieId)
        {
            return (from movieShow in _movieContext.MovieShows
                join cine in _movieContext.Cinemas on movieShow.CinemaId equals cine.Id
                where movieShow.MovieId.Equals(movieId)
                select new MovieShowDto
                {
                    Id = movieShow.Id,
                    CinemaName = cine.Name,
                    ShowTime = movieShow.ShowTime,
                    CinemaId = cine.Id,
                    MovieId = movieShow.MovieId
                }).ToList();

        }
    }
}
