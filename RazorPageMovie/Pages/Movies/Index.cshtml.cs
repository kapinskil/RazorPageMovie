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
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovie.Models.RazorPageMovieContext _context;

        public IndexModel(RazorPageMovie.Models.RazorPageMovieContext context)
        {
            _context = context;
        }

        public IList<Moveies> Moveies { get;set; }

        public async Task OnGetAsync()
        {
            Moveies = await _context.Moveies.ToListAsync();
        }
    }
}
