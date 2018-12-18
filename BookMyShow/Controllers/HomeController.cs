using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookMyShow.Models;
using UtilityProject.ApiConnection;
using UtilityProject.Dto_Objects;

namespace BookMyShow.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiConnection _apiConnection;

        public HomeController(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }
        public async Task<ActionResult> Index()
        {
            MovieModel movieModel = new MovieModel();
            movieModel.MovieDtos = await _apiConnection.RequestGet<List<MovieDto>>("GetMovies");
            Session.Add("Movies", movieModel.MovieDtos);
            return View(movieModel);
        }

        public async Task<ActionResult> GetMovieShowById(int id)
        {
            MovieModel movieModel = new MovieModel();
           
            movieModel.MovieShowDtos = await _apiConnection.RequestGet<List<MovieShowDto>>($"GetMovieShowById?movieId={id}");
            Session.Add("MoviesShow",movieModel.MovieShowDtos);

            foreach (var temp in movieModel.MovieShowDtos)
            {
                temp.Hours = temp.ShowTime.Hours;
                temp.Minute = temp.ShowTime.Minutes;
            }

            return View("MovieShowDetails",movieModel);
        }

        public async Task<JsonResult> CheckSeatAvailbility(int cinemaId,int movieId,string time)
        {
            TimeSpan timeSpan = TimeSpan.Parse(time);

            int noOfSeatsAvialble =
                await _apiConnection.RequestGet<int>(
                    $"GetAvailableSeats?movieId={movieId}&cinemaId={cinemaId}&time={timeSpan}");
            string s = $"Bingo, Hurry Up Few seats remaining . Remaining Seats are :-" + noOfSeatsAvialble;
            return Json(new {s},JsonRequestBehavior.AllowGet);
        }

        public ActionResult SeatSlection(int movieShowId)
        {
            MovieModel movieModel = new MovieModel();
            
            List<MovieShowDto> movieShowDtos =(List<MovieShowDto>) Session["MoviesShow"];
            movieModel.MovieShowDtos = movieShowDtos;
            MovieShowDto movieShowDto = movieShowDtos.SingleOrDefault(x => x.Id == movieShowId);
            List<MovieDto> movieDtos = (List<MovieDto>)Session["Movies"];
            movieModel.MovieDtos = movieDtos;
            movieModel.BookingDto = new BookingDto();
            if (movieShowDto != null)
            {
                movieModel.BookingDto.CinemaId = movieShowDto.CinemaId;
                movieModel.BookingDto.MovieId = movieShowDto.MovieId;
                movieModel.BookingDto.MovieName =
                    movieModel.MovieDtos.SingleOrDefault(x => x.Id == movieShowDto.MovieId)?.MovieName;
                movieModel.BookingDto.MovieTime = movieShowDto.ShowTime;
            }

            return  View("SeatSlection", movieModel);

        }


    }
}