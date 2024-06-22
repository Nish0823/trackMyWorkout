using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using TrackMyWorkouts.Services.Interfaces;
using Microsoft.AspNet.Identity;
using TrackMyWorkouts.Data.DataModels;
using TrackMyWorkouts.ViewModels;

namespace TrackMyWorkouts.Pages
{
    public partial class History
    {
        [Inject]
        private IExercise exerciseService { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }



        private IEnumerable<ExerciseType> exerciseList = new List<ExerciseType>();
        private IEnumerable<ExerciseHistoryViewModel> vmList = new List<ExerciseHistoryViewModel>();
        private string appUserId;

        protected override async Task OnInitializedAsync()
        {
            if (authenticationState != null)
            {
                var authState = await authenticationState;
                appUserId = authState.User.Identity.GetUserId();
            }

            exerciseList = await exerciseService.GetExercises();

        }

        private async Task GetExerciseHistory(ChangeEventArgs arg)
        {
            var exHistoryList  = new List<ExerciseHistoryViewModel>();
            var exTypeId = Convert.ToInt32(arg.Value);

            //get all the exercises with this extypeId that belongs to this user

            var usersExerciseHistory = await exerciseService.GetUsersExerciseHistory(exTypeId, appUserId);
            
            foreach(var exercise in usersExerciseHistory)
            {
                exHistoryList.Add(new ExerciseHistoryViewModel() { Date = exercise.ExerciseDate, Log = exercise.SetLogs });
            }

            vmList = exHistoryList;
        }


    }
}
