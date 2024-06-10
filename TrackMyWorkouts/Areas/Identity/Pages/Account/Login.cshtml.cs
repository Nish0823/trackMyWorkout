using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using TrackMyWorkouts.Data.DataModels;
using Microsoft.AspNetCore.Components;

namespace TrackMyWorkouts.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        [Required]
        public string Username { get; set; }

        [BindProperty]
        [Required]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
       
            var result = await _signInManager.PasswordSignInAsync(Username, Password, true, lockoutOnFailure: false);

            if(!result.Succeeded) 
            {
                ModelState.AddModelError(string.Empty, "Invalid login attemp");
                return Page();
            }
           

            return Redirect("/create");
        }
    }
}
