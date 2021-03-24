using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_IS413.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options) :base(options)
        {

        }
        public DbSet<MovieResponse> movieResponses { get; set; } //projects = movieResponses
    }
}
