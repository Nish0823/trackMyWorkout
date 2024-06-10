using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TrackMyWorkouts.Services.Interfaces;

namespace TrackMyWorkouts.Pages
{
    
    public partial class Create
    {
        [Inject]
        private IExercise exerciseService {  get; set; }

        //private properties
        private bool showNotification = false;
        private string exerciseName;
        private string display = "none";
        private bool isButtonDisabled = false;
        private string notificationMessage;

        [Inject]
        private AuthenticationStateProvider authenticationStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var ap  = await authenticationStateProvider.GetAuthenticationStateAsync();

            Console.WriteLine(ap);
        }
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

            var newExercise =  await exerciseService.CreateExercise(exerciseName);

            notificationMessage = $"{newExercise.Name} successfully created";
            showNotification = true;
            exerciseName = "";
        }

       
    }
}
