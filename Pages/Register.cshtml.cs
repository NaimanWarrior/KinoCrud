using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KinoCrud.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();
        public string? ErrorMessage { get; set; }
        public class InputModel
        {
            [Required(ErrorMessage = "Input Name")]
            public string Name { get; set; } = string.Empty;
            [Required(ErrorMessage = "Input Email")]
            [EmailAddress(ErrorMessage = "Incorrect Email format")]
            public string Email { get; set; } = string.Empty;
            [Required(ErrorMessage = "Input Password")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "passwords don't match")]
            public string ConfirmPassword { get; set; } = string.Empty;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            var newUser = new IdentityUser { UserName = Input.Name, Email = Input.Email };
            var result = await _userManager.CreateAsync(newUser, Input.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, isPersistent: true);
                return RedirectToPage("/Index");
            } else
            {
                foreach(var errors in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, errors.Description);
                }
                return Page();
            }
        }
    }
}
