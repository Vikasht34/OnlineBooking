using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityProject.Dto_Objects
{
   public class MovieShowDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public TimeSpan ShowTime { get; set; }
        public int Hours { get; set; }
        public int Minute { get; set; }
        public string CinemaName { get; set; }

    }
}
