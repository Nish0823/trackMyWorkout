using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrackMyWorkouts.Data.DataModels
{
    public class ExerciseTypeCarriedOut
    {
   
        public int Id { get; set; }

        public int ExerciseCarriedOutId { get; set; }
        public ExerciseCarriedOut ExerciseCarriesOut { get; set; }

        public int ExerciseTypeId { get; set; }
        public ExerciseType ExerciseType { get; set; }
    }
}
