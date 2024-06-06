using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using TrackMyWorkouts.Data.DataModels;
using TrackMyWorkouts.Services.Interfaces;
using TrackMyWorkouts.ViewModels;

namespace TrackMyWorkouts.Pages
{
    public partial class LogWorkouts
    {
        [Inject]
        private  IExercise exerciseService { get; set; }

        private DateTime currentDate;
        private IEnumerable<ExerciseType> exerciseList = new List<ExerciseType>();
        private IEnumerable<WorkoutLogViewModel> vmList = new List<WorkoutLogViewModel>();
        

        protected override async Task OnInitializedAsync()
        {
            currentDate = DateTime.Now;
            exerciseList = await exerciseService.GetExercises();
            vmList = await exerciseService.WorkoutLogViewModelsList(currentDate);
        }


        private async Task HandleCallBack((string eventType, object obj) data)
        {
            string eventType = data.eventType;
            object eventData = data.obj;
            
            switch (eventType)
            {
                case "saveSet":
                    await SaveSet((SetLogViewModel) eventData);
                    break;
                case "addEmptySet":
                    await AddNewSetToExercise((int) eventData);
                    break;
                case "deleteSet":
                    await DeleteSetLog((int) eventData);
                    break;
                default:
                    break;
            }
        }

        

        private async Task GoBackADay()
        {
            currentDate = currentDate.AddDays(-1);
            vmList = await exerciseService.WorkoutLogViewModelsList(currentDate);
        }

        private async Task GoForwardADay()
        {
            currentDate = currentDate.AddDays(+1);
            vmList = await exerciseService.WorkoutLogViewModelsList(currentDate);
        }

        private async Task AddWorkout(ChangeEventArgs arg)
        {
            var exTypeId = Convert.ToInt32(arg.Value);
             bool hasExerciseId = vmList.Any(x => x.ExerciseTypeId == exTypeId);
            if (!hasExerciseId)
            {
                var newLog = await exerciseService.CreateNewLog(exTypeId, currentDate);
                vmList = await exerciseService.WorkoutLogViewModelsList(currentDate);
            }   
        }

        private async Task SaveSet(SetLogViewModel set)
        {
            await exerciseService.SaveSet(set);
            vmList = await exerciseService.WorkoutLogViewModelsList(currentDate);           
        }

        private async Task AddNewSetToExercise(int exerciseCarriedOutId)
        {
            await exerciseService.AddNewSetToExercise(exerciseCarriedOutId);
            vmList = await exerciseService.WorkoutLogViewModelsList(currentDate);
        }

        private async Task DeleteSetLog(int setLogId)
        {
            await exerciseService.DeleteSetLog(setLogId);
            vmList = await exerciseService.WorkoutLogViewModelsList(currentDate);
        }
    }
}
