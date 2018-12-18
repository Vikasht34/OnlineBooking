using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityProject.Dto_Objects
{
   public class BookingDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public int UserId { get; set; }
        public int Seats { get; set; }
        public TimeSpan MovieTime { get; set; }
        public DateTime MovieDate { get; set; }
        public string MovieName { get; set; }

    }
}
