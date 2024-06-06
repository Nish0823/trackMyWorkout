using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyWorkouts.Data.DataModels
{
    public class ExerciseCarriedOut
    {
        public int Id { get; set; }
        
        [Column(TypeName = "Date")]
        public DateTime ExerciseDate { get; set; }

        public virtual ICollection<ExerciseTypeCarriedOut> ExerciseTypesCarriedOut { get; set; }
        public virtual ICollection<SetLog> SetLogs { get; set; } 
    }
}
