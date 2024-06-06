using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TrackMyWorkouts.ViewModels.AccountsViewModels;

namespace TrackMyWorkouts.Pages
{
    public partial class Register
    {
        private RegisterViewModel registerModel = new RegisterViewModel();

        private async Task HandleRegistration()
        {
            //var user = new IdentityUser { UserName = registerModel.Email, Email = registerModel.Email };
            //var result = await UserManager.CreateAsync(user, registerModel.Password);
            //if (result.Succeeded)
            //{
            //    var token = await UserManager.GenerateEmailConfirmationTokenAsync(user);
            //    var confirmationLink = Navigation.ToAbsoluteUri($"/confirmemail?userId={user.Id}&token={token}");
            //    // Send the email with the confirmation link
            //}
            //else
            //{
            //    // Handle errors
            //}
        }
    }
}
