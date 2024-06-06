using Azure.Communication.Email;
using TrackMyWorkouts.Services.Interfaces;

namespace TrackMyWorkouts.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly EmailClient _emailClient;
        private readonly string _senderAddress;

        public EmailService(IConfiguration configuration)
        {
            var connectionString = configuration["AzureCommunicationServices:ConnectionString"];
            _emailClient = new EmailClient(connectionString);
            _senderAddress = "DoNotReply@ee69cbdc-b4e6-44e3-87d0-4a832de775ee.azurecomm.net";
        }


        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
   
            var htmlContent = $"<html><body><h1>Quick send email test</h1><br/><h4>This email message is sent from track  my workout.</h4><p>{message} I am the best!!</p></body></html>";
         
            //var emailContent = new EmailContent(subject: subject);
            //emailContent.PlainText = message;

            //var emailAddress = new EmailAddress(toEmail);

            //var emailAddressList = new List<EmailAddress> { emailAddress };

            //var emailRecepient = new EmailRecipients(emailAddressList);

            //var emailMessage = new EmailMessage(senderAddress: _senderAddress, emailRecepient, emailContent);

            await _emailClient.SendAsync(Azure.WaitUntil.Completed,_senderAddress, toEmail, subject, htmlContent);

        }
    }
}
