using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.NetworkInformation;
using System;
using TrackMyWorkouts.Data.DataModels;

namespace TrackMyWorkouts.Areas.Identity.Pages.Account
{
    [IgnoreAntiforgeryToken]
    public class LogoutModel : PageModel
    {
    
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public LogoutModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            await OnPostAsync();
            return Redirect("~/");

        }

        public async Task OnPostAsync()
        {
            if (_signInManager.IsSignedIn(User))
            {
                await _signInManager.SignOutAsync();
            } 
        }
    }
}
