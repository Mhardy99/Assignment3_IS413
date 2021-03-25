using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment3_IS413.Models;

namespace Assignment3_IS413.Controllers
{

    public class MovieResponsesController : Controller
    {
        private readonly MovieDbContext _context;

        public MovieResponsesController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: MovieResponses
        public async Task<IActionResult> Index()
        {
            return View(await _context.movieResponses.ToListAsync());
        }

        // GET: MovieResponses/Details/5
        public async Task<IActionResult> LogDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieResponse = await _context.movieResponses
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movieResponse == null)
            {
                return NotFound();
            }

            return View(movieResponse);
        }
        public IActionResult MyPodcasts()
        {
            return View();
        }


        // GET: MovieResponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieID,Category,Title,YearReleased,DirectorName,MovieRating,IsEdited,IsLentTo,Notes")] MovieResponse movieResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieResponse);
        }

        // GET: MovieResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieResponse = await _context.movieResponses.FindAsync(id);
            if (movieResponse == null)
            {
                return NotFound();
            }
            return View(movieResponse);
        }

        // POST: MovieResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieID,Category,Title,YearReleased,DirectorName,MovieRating,IsEdited,IsLentTo,Notes")] MovieResponse movieResponse)
        {
            if (id != movieResponse.MovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieResponseExists(movieResponse.MovieID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movieResponse);
        }

        // GET: MovieResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieResponse = await _context.movieResponses
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movieResponse == null)
            {
                return NotFound();
            }

            return View(movieResponse);
        }

        // POST: MovieResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieResponse = await _context.movieResponses.FindAsync(id);
            _context.movieResponses.Remove(movieResponse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieResponseExists(int id)
        {
            return _context.movieResponses.Any(e => e.MovieID == id);
        }
    }
}
