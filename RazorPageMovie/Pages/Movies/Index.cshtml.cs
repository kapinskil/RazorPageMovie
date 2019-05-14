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
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovie.Models.RazorPageMovieContext _context;

        public IndexModel(RazorPageMovie.Models.RazorPageMovieContext context)
        {
            _context = context;
        }
        //Search
        public IList<Moveies> Moveies { get;set; }
        [BindProperty(SupportsGet =true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet =true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            var movies = from m in _context.Moveies select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }
            Moveies = await movies.ToListAsync();
        }
    }
}
