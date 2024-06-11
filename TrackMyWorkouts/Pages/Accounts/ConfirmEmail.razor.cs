using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using TrackMyWorkouts.Services.Interfaces;

namespace TrackMyWorkouts.Pages.Accounts
{
    
    public partial class ConfirmEmail
    {
        [Inject]
        public IRegistrationService registrationService { get; set; }

        [Parameter]
        public string UserId { get; set; }

        [Parameter]
        public string Token { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            // Extract query parameters
            var uri = Navigation.ToAbsoluteUri(Navigation.Uri);
            var queryParams = QueryHelpers.ParseQuery(uri.Query);

            if (queryParams.TryGetValue("userId", out var userId))
            {
                UserId = userId;
            }

            if (queryParams.TryGetValue("token", out var token))
            {
                Token = token;
            }

            // Your logic to handle userId and token
            Console.WriteLine($"UserId: {UserId}, Token: {Token}");
        }

        //private bool ValidateToken(string userId, string token)
        //{
        //    if(registrationService.ValidateToken(token))
        //    {

        //    }
        //}
    }
}
