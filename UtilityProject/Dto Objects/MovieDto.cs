using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityProject.Dto_Objects
{
   public class MovieDto
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int? MovieRating { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
    }
}
