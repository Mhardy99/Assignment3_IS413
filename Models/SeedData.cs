using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_IS413.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            MovieDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<MovieDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.movieResponses.Any())
            {
                context.movieResponses.AddRange(
                    new MovieResponse
                    {
                        Category= "Action",
                        Title= "Avengers",
                        YearReleased = 2008,
                        DirectorName = "Josh Whedon",
                        MovieRating = "PG-13",
                        IsEdited = false,
                        IsLentTo = "",
                        Notes= "It was good."

                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
