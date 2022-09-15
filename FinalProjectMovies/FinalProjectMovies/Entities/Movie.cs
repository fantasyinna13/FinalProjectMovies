using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectMovies.Entities
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<MovieToGenres> MovieToGenre { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}