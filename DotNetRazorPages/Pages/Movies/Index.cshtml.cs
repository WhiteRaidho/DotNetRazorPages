using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DotNetRazorPages.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNetRazorPages.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly DotNetRazorPages.Models.DotNetRazorPagesContext _context;

        public IndexModel(DotNetRazorPages.Models.DotNetRazorPagesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {

            IQueryable<string> genreQuery = _context.Movie.OrderBy(m => m.Genre).Select(m => m.Genre);
            
            var movies = _context.Movie.Select(x => x);
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
