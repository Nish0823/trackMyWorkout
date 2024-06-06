using TrackMyWorkouts.Data.DataModels;
using TrackMyWorkouts.ViewModels;

namespace TrackMyWorkouts.Services.Interfaces
{
    public interface IExercise
    {
        Task AddNewSetToExercise(int exerciseCarriedOutId);
        Task<ExerciseType> CreateExercise(string exerciseName);
        Task<ExerciseCarriedOut> CreateNewLog(int exTypeId, DateTime currentDate);
        Task DeleteSetLog(int setLogId);
        Task<IEnumerable<ExerciseType>> GetExercises();
        Task<IEnumerable<ExerciseTypeCarriedOut>> GetExercisesForThisDate(DateTime utcNow);
        Task SaveSet(SetLogViewModel set);
        Task<IEnumerable<WorkoutLogViewModel>> WorkoutLogViewModelsList(DateTime date);
    }
}
