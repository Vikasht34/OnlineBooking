using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceLayer;
using UtilityProject.Dto_Objects;

namespace WebApiLayer.Controllers
{
    public class MovieController : ApiController
    {
        private readonly IMovieServiceLayer _movieServiceLayer;

        public MovieController(IMovieServiceLayer movieServiceLayer)
        {
            _movieServiceLayer = movieServiceLayer;
        }

        [HttpGet]
        [Route("api/GetMovies")]
        public HttpResponseMessage GetMovies()
        {
            return Request.CreateResponse(_movieServiceLayer.GetMovies());
        }

        [HttpGet]
        [Route("api/GetMovieShowById")]
        public HttpResponseMessage GetMovieShowById(int movieId)
        {
            return Request.CreateResponse(_movieServiceLayer.GetMovieShowByMovieId(Convert.ToInt32(movieId)));
        }

        [HttpPost]
        [Route("api/BookMovie")]
        public HttpResponseMessage BookMovie(BookingDto bookingDto)
        {
            return Request.CreateResponse(_movieServiceLayer.BookMovie(bookingDto));
        }

        [HttpGet]
        [Route("api/GetAvailableSeats")]
        public HttpResponseMessage GetAvailableSeats(int movieId, int cinemaId, TimeSpan time)
        {
            return Request.CreateResponse(_movieServiceLayer.GetAvailableSeaats(movieId, cinemaId, time));
        }
    }
}
