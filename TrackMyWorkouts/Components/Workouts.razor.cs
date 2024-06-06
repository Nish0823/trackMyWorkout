using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection.Metadata;
using TrackMyWorkouts.Data.DataModels;
using TrackMyWorkouts.ViewModels;

namespace TrackMyWorkouts.Components
{
    public partial class Workouts
    {
     
        [Parameter]
        public WorkoutLogViewModel WorkOutViewModel { get; set; }
        [Parameter]
        public EventCallback<SetLogViewModel> OnSaveSet { get; set; }
        [Parameter]
        public EventCallback<int> OnAddSet { get; set; }

        [Parameter]
        public EventCallback<(string, object)> OnEventOccurred { get; set; }

        private bool showNotification;

        private void EditActionClicked(SetLogViewModel set)
        {
            set.IsReadOnly = false;
        }

        private async Task SaveSet(SetLogViewModel set)
        {
            if(set.IsReadOnly) { return; }
            await OnEventOccurred.InvokeAsync(("saveSet", set));
            set.IsReadOnly = true;
            showNotification = true;
        }

        private async Task AddSet()
        {
            showNotification = false;
            await OnEventOccurred.InvokeAsync(("addEmptySet", WorkOutViewModel.ExerciseCarriedOutId));
        }

        private async Task DeleteSet(int setLogId)
        {
            await OnEventOccurred.InvokeAsync(("deleteSet", setLogId));
        }
    } 
}
