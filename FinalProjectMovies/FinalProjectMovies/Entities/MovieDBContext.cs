using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalProjectMovies.Entities
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext() : base("Server=DESKTOP-ADQJJU8;Database=Films;Trusted_Connection=True;")
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genres> Genre { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<MovieToGenres> MovieToGenres { get; set; }
    }
}