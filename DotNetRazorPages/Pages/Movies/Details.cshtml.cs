using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DotNetRazorPages.Models;

namespace DotNetRazorPages.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly DotNetRazorPages.Models.DotNetRazorPagesContext _context;

        public DetailsModel(DotNetRazorPages.Models.DotNetRazorPagesContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                Movie = await _context.Movie.FirstOrDefaultAsync();
            }
            else
            {
                Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            }

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
