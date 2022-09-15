using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectMovies.Entities
{
    public class MovieToGenres
    {
        public int MovieToGenresID { get; set; }
        public int MovieID { get; set; }
        public int GenresID { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Genres Genres { get; set; }
    }
}