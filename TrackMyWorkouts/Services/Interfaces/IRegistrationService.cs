namespace TrackMyWorkouts.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task SendConfirmationEmail(string toEmail, string token);

        Task RegisterUser(string email, string passWord);
    }
}
