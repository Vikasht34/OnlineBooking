//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movie
    {
        public Movie()
        {
            this.Bookings = new HashSet<Booking>();
            this.MovieShows = new HashSet<MovieShow>();
        }
    
        public int Id { get; set; }
        public string MovieName { get; set; }
        public Nullable<int> MovieRating { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
    
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<MovieShow> MovieShows { get; set; }
    }
}
