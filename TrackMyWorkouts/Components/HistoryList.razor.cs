using Microsoft.AspNetCore.Components;

using TrackMyWorkouts.ViewModels;

namespace TrackMyWorkouts.Components
{
    public partial class HistoryList
    {
        [Parameter]
        public ExerciseHistoryViewModel HistoryViewModel { get; set; }

    }
}
