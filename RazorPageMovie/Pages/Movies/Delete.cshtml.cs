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
    public class DeleteModel : PageModel
    {
        private readonly RazorPageMovie.Models.RazorPageMovieContext _context;

        public DeleteModel(RazorPageMovie.Models.RazorPageMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Moveies = await _context.Moveies.FindAsync(id);

            if (Moveies != null)
            {
                _context.Moveies.Remove(Moveies);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
