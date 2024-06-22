using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrackMyWorkouts.Data.DataModels
{
    public class SetLog
    {
        
        public int Id { get; set; }

        public int Reps { get; set; }

        public int Weight { get; set; }


        public int ExerciseCarriedOutId { get; set; }
        public ExerciseCarriedOut ExercisesCarriedOut { get; set; } = null!;
    }
}
