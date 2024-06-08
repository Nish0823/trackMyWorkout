using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using TrackMyWorkouts.Configurations;
using TrackMyWorkouts.Data.DataModels;
using TrackMyWorkouts.Services.Interfaces;

namespace TrackMyWorkouts.Services.Implementations
{
    public class RegistrationService : IRegistrationService
    {

        private readonly IEmailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager; 
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly HostUrlSettings _hostUrlSettings;

        private string hostUrl;
        public RegistrationService(IEmailService emailService, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment, IOptions<HostUrlSettings> hostUrlSettings) 
        {
            _emailService = emailService;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _hostUrlSettings = hostUrlSettings.Value;
        
        }


        public async Task RegisterUser(string email, string passWord)
        {
            var user = new ApplicationUser { UserName = email, Email = email };
            var result = await CreateUser(user, passWord);

            if (result.Succeeded) 
            {
                SetHostUrl();
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = $"{hostUrl}/confirmemail?userId={user.Id}&token={token}";

                // Send the email with the confirmation link

                await _emailService.SendEmailAsync(user.Email, "register", confirmationLink);
            }
        }

        public Task SendConfirmationEmail(string toEmail, string token)
        {
            throw new NotImplementedException();
        }

        private void SetHostUrl() 
        {
            if(_webHostEnvironment.IsDevelopment()) 
            {
                hostUrl = _hostUrlSettings.DevelopmentHostUrl;
            }

            if (_webHostEnvironment.IsProduction())
            {
                hostUrl = _hostUrlSettings.ProductionHostUrl;
            }
        }

        private async Task<IdentityResult> CreateUser(ApplicationUser user, string passWord)
        {
            
            var result = await _userManager.CreateAsync(user, passWord);
            return result;
        }
    }
}
