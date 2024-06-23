using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackMyWorkouts.Data.DataModels;

namespace TrackMyWorkouts.ViewModels
{
    public class ExerciseHistoryViewModel
    {
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public  DateTime Date { get; set; }
        public IEnumerable<SetLog> Log { get; set; }
    }
}
