using TrackMyWorkouts.Data.DataModels;
using TrackMyWorkouts.ViewModels;

namespace TrackMyWorkouts.Services.Interfaces
{
    public interface IExercise
    {
        Task AddNewSetToExercise(int exerciseCarriedOutId);
        Task<ExerciseType> CreateExercise(string exerciseName);
        Task<ExerciseCarriedOut> CreateNewLog(int exTypeId, DateTime currentDate, string appUserId);
        Task DeleteExerciseOut(int exCarriedOutId);
        Task DeleteSetLog(int setLogId);
        Task<IEnumerable<ExerciseType>> GetExercises();
        Task<IEnumerable<ExerciseCarriedOut>> GetUsersExerciseHistory(int exTypeId, string appUserId);
        Task<IEnumerable<ExerciseCarriedOut>> GetUsersExercisesForThisDate(DateTime utcNow, string appUserId);
        Task SaveSet(SetLogViewModel set);
        Task<IEnumerable<WorkoutLogViewModel>> WorkoutLogViewModelsList(DateTime date, string appUserId);
    }
}
