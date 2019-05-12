using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Models;
using RazorPageMovie.Move;

namespace RazorPageMovie.Movies
{
    public class EditModel : PageModel
    {
        private readonly RazorPageMovie.Models.RazorPageMovieContext _context;

        public EditModel(RazorPageMovie.Models.RazorPageMovieContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Moveies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoveiesExists(Moveies.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MoveiesExists(int id)
        {
            return _context.Moveies.Any(e => e.ID == id);
        }
    }
}
