using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_IS413.Models
{
    public class EFMovieRepository : IMovieRepository
    {

        private MovieDbContext _context;
        //constructor
        public EFMovieRepository (MovieDbContext context)
        {
            _context = context;
        }
        public IQueryable<MovieResponse> movieResponses => _context.movieResponses;
    }
}
