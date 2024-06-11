using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TrackMyWorkouts.Services.Interfaces;

namespace TrackMyWorkouts.Pages
{
    [Authorize]
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

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }

        protected override async void OnInitialized()
        {
            if(authenticationState != null)
            {
                var authState = await authenticationState;
                var user = authState?.User;
                if (!user.Identity.IsAuthenticated)
                {
                    Console.WriteLine("noy authenticated");
                }
                else if (user.Identity.IsAuthenticated)
                {
                    Console.WriteLine("authenticated");
                }
            }
            
        }
        private void HandleInputChange(ChangeEventArgs e)
        {
            exerciseName = e.Value.ToString();
            UpdateDisplay();
           
        }

        protected override void OnParametersSet()
        {
            Console.WriteLine("called");
            base.OnParametersSet();
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
