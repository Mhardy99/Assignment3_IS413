using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_IS413.Models
{
    public class TempStorage
    {
        private static List<MovieResponse> listmovies = new List<MovieResponse>();

        public static IEnumerable<MovieResponse> Listmovies => listmovies;

        public static void AddMovie(MovieResponse listallmovies)
        {
            listmovies.Add(listallmovies);
        }
    }
}
