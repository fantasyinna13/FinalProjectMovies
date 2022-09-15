using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectMovies.Entities
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public decimal Price { get; set; }
        public int MovieID { get; set; }

        public virtual Movie Movie { get; set; }
    }
}