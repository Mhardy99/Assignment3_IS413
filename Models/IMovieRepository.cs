using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_IS413.Models
{
    public interface IMovieRepository
    {
        IQueryable<MovieResponse> movieResponses { get; } //Projects = movieResponses
    }
}
