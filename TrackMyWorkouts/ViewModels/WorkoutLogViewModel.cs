using TrackMyWorkouts.Data.DataModels;

namespace TrackMyWorkouts.ViewModels
{
    public class WorkoutLogViewModel
    {
        public int ExerciseCarriedOutId { get; set; }
        public IEnumerable<SetLogViewModel> SetLogs { get; set; }
        public string ExerciseName { get; set; }
        public int ExerciseTypeId { get; internal set; }
    }
}
