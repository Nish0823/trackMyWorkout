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
        public string ApplicationUserId { get; set; } = null!;

        public int? ExerciseTypeId { get; set; }


        public virtual ExerciseType ExerciseType { get; set; } = null!;
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;
        public virtual ICollection<SetLog> SetLogs { get; set; } = null!;
    }
}
