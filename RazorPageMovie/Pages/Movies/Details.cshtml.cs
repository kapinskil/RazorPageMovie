using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Models;
using RazorPageMovie.Move;

namespace RazorPageMovie.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPageMovie.Models.RazorPageMovieContext _context;

        public DetailsModel(RazorPageMovie.Models.RazorPageMovieContext context)
        {
            _context = context;
        }

        public Moveies Moveies { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Moveies = await _context.Moveies.FirstOrDefaultAsync(m => m.ID == id);

            if (Moveies == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
