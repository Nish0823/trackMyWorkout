
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using TrackMyWorkouts.Data.DataModels;
using TrackMyWorkouts.Services.Interfaces;
using TrackMyWorkouts.ViewModels.AccountsViewModels;

namespace TrackMyWorkouts.Pages
{
    public partial class Register
    {

        [Inject]
        private IRegistrationService registrationService {  get; set; }  

        private RegisterViewModel registerModel = new RegisterViewModel();

        private async Task HandleRegistration()
        {
            await registrationService.RegisterUser(registerModel.Email, registerModel.Password);
           

            //string hostUrl;
            //if (webHostEnvironment.IsDevelopment()) // Assuming development uses localhost
            //{
            //    hostUrl = "https://localhost:54051"; // Replace PORT with your local port number
            //}
            //else
            //{
            //    // Assuming production uses domain name
            //    hostUrl = "https://logmyworkouts.azurewebsites.net"; // Replace with your production domain
            //}

            //if (result.Succeeded)
            //{
            //    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            //    var confirmationLink = $"{hostUrl}/confirmemail?userId={user.Id}&token={token}";

            //    // Send the email with the confirmation link

            //    await emailService.SendEmailAsync(user.Email, "register", confirmationLink);
            //}
            //else
            //{
            //    // Handle errors
            //}
        }
    }
}
