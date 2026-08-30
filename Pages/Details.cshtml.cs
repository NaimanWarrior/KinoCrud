using KinoCrud.DbContext;
using KinoCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KinoCrud.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Kino Movie { get; set; } = default!;

        public string EmbedTrailerUrl { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Kinos.FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            Movie = movie;

            EmbedTrailerUrl = ConvertToEmbedUrl(Movie.TrailterUrl);

            return Page();
        }

        private string ConvertToEmbedUrl(string originalUrl)
        {
            if (string.IsNullOrEmpty(originalUrl)) return string.Empty;

            if (originalUrl.Contains("watch?v="))
            {
                return originalUrl.Replace("watch?v=", "embed/");
            }
            if (originalUrl.Contains("youtu.be/"))
            {
                return originalUrl.Replace("youtu.be/", "www.youtube.com/embed/");
            }

            return originalUrl;
        }
    }
}
