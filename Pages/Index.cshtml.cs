using KinoCrud.DbContext;
using KinoCrud.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KinoCrud.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public IndexModel(
            AppDbContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [BindProperty]
        public InputModel Input { get; set; } = new();
        public class InputModel
        {
            [Required(ErrorMessage = "Input Email")]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Input Password")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            public bool RememberMe { get; set; }
        }

        public IList<Kino> Movies { get; set; } = new List<Kino>();

        public async Task OnGetAsync()
        {
                Movies = await _context.Kinos.AsNoTracking().ToListAsync();   
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    user.UserName!,
                    Input.Password,
                    Input.RememberMe,
                    lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Email");
            }
            Movies = await _context.Kinos.AsNoTracking().ToListAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}