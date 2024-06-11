using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyWorkouts.Data.DataModels
{
    public class ExerciseCarriedOut
    {
        public int Id { get; set; }
        
        [Column(TypeName = "Date")]
        public DateTime ExerciseDate { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<ExerciseTypeCarriedOut> ExerciseTypesCarriedOut { get; set; }
        public virtual ICollection<SetLog> SetLogs { get; set; } 
    }
}
