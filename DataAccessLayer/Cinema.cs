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
    
    public partial class Cinema
    {
        public Cinema()
        {
            this.Bookings = new HashSet<Booking>();
            this.MovieShows = new HashSet<MovieShow>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Seats { get; set; }
    
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<MovieShow> MovieShows { get; set; }
    }
}
