namespace TrackMyWorkouts.ViewModels
{
    public class SetLogViewModel
    {
        public int SetLogId { get; set; }
        public int ExerciseCarriedOutId { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }

        public bool IsReadOnly = true;

      
        public void ReadOnlyToggle()
        {
            IsReadOnly = !IsReadOnly;
        }
    }
}
