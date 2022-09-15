using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectMovies.Entities
{
    public class Genres
    {
        public int GenresID { get; set; }
        public string GenresName { get; set; }

        public virtual ICollection<MovieToGenres> MovieToGenre { get; set; }
    }
}