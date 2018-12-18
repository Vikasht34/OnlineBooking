using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilityProject.Dto_Objects;

namespace BookMyShow.Models
{
    public class MovieModel
    {
        public List<MovieDto> MovieDtos { get; set; }
        public List<MovieShowDto> MovieShowDtos { get; set; }
        public BookingDto BookingDto { get; set; }
    }
}