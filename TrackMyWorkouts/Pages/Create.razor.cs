using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;
using TrackMyWorkouts.Services.Interfaces;

namespace TrackMyWorkouts.Pages
{
    public partial class Create
    {
        [Inject]
        private IExercise exerciseService {  get; set; }

        [Inject]
        private  IEmailService EmailService { get; set; }

        //private properties
        private bool showNotification = false;
        private string exerciseName;
        private string display = "none";
        private bool isButtonDisabled = false;
        private string notificationMessage;
  

        private void HandleInputChange(ChangeEventArgs e)
        {
            exerciseName = e.Value.ToString();
            UpdateDisplay();
           
        }

        private void UpdateDisplay()
        {
            if (String.IsNullOrWhiteSpace(exerciseName))
            {
                display = "block";
                isButtonDisabled = true;
            }
            else
            {
                display = "none";
                isButtonDisabled = false;
            }
        }

        private async Task CreateExercise()
        {
            if (String.IsNullOrWhiteSpace(exerciseName))
            {
                display = "block";
                isButtonDisabled = true;
                return;
            }

            await EmailService.SendEmailAsync("nshntshr@gmail.com", "whats up bboy", "yoyoyo");
            var newExercise =  await exerciseService.CreateExercise(exerciseName);

            notificationMessage = $"{newExercise.Name} successfully created";
            showNotification = true;
            exerciseName = "";
        }

       
    }
}
