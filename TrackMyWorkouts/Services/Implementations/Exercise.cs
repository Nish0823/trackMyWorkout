using Microsoft.EntityFrameworkCore;
using TrackMyWorkouts.Data;
using TrackMyWorkouts.Data.DataModels;
using TrackMyWorkouts.Services.Interfaces;
using TrackMyWorkouts.ViewModels;

namespace TrackMyWorkouts.Services.Implementations
{
    public class Exercise : IExercise
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public Exercise(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ExerciseType> CreateExercise(string exerciseName)
        {
            ExerciseType newExercise = new ExerciseType(exerciseName);
            await _applicationDbContext.ExerciseType.AddAsync(newExercise);
            await _applicationDbContext.SaveChangesAsync();
            return newExercise;
        }

        public async Task<ExerciseCarriedOut> CreateNewLog(int exTypeId, DateTime currentDate, string appUserId)
        {
            var newExerciseCarriedOut = new ExerciseCarriedOut() { ExerciseDate = currentDate, ApplicationUserId = appUserId, ExerciseTypeId = exTypeId };
            await _applicationDbContext.ExerciseCarriedOut.AddAsync(newExerciseCarriedOut);
            await _applicationDbContext.SaveChangesAsync();
            return newExerciseCarriedOut;
        }

        public async Task<IEnumerable<ExerciseType>> GetExercises()
        {
            var exerciseList = await _applicationDbContext.ExerciseType
                .AsNoTracking().ToListAsync();
            return exerciseList;
        }


        private async Task<IEnumerable<SetLog>> GetListOfSetLogsForExerciseCarriedOut(int exCarriedOutId)
        {
            var exerciseCarriedOut = await  _applicationDbContext.ExerciseCarriedOut.Include(e => e.SetLogs)
                .FirstOrDefaultAsync(ex => ex.Id == exCarriedOutId);
            
            return exerciseCarriedOut.SetLogs.ToList();
        }

        public async Task<IEnumerable<ExerciseCarriedOut>> GetUsersExercisesForThisDate(DateTime utcNow, string appUserId)
        {
            DateTime searchDate = utcNow.Date;
            var exercises = await _applicationDbContext.ExerciseCarriedOut
                                                .AsNoTracking()
                                                .Include(ex => ex.ExerciseType)
                                                .Where(e => e.ExerciseDate == searchDate && e.ApplicationUserId == appUserId).ToListAsync();


            return exercises;
        }

    

        public async Task<IEnumerable<WorkoutLogViewModel>> WorkoutLogViewModelsList(DateTime date, string appUserId)
        {
            List<WorkoutLogViewModel> workoutLogViewModels = new List<WorkoutLogViewModel>();

            var exCarriedOut = await GetUsersExercisesForThisDate(date, appUserId);

            foreach (var workOutLog in exCarriedOut)
            {
                var newVm = new WorkoutLogViewModel()
                {
                    ExerciseCarriedOutId = workOutLog.Id,
                    ExerciseName = workOutLog.ExerciseType.Name,
                    ExerciseTypeId = workOutLog.ExerciseType.Id,
                    SetLogs = await GetSetLogsViewModel(workOutLog.Id),
                };

                workoutLogViewModels.Add(newVm);

            }

            return workoutLogViewModels;
        }

        private async Task<IEnumerable<SetLogViewModel>> GetSetLogsViewModel(int exerciseCarriedOutId)
        {
            var setLostVmList = new List<SetLogViewModel>();
            var setLogs = await GetListOfSetLogsForExerciseCarriedOut(exerciseCarriedOutId);

            foreach (var setLog in setLogs) 
            {
                setLostVmList.Add(new SetLogViewModel()
                {
                    SetLogId = setLog.Id,
                    ExerciseCarriedOutId = setLog.ExerciseCarriedOutId,
                    Reps = setLog.Reps,
                    Weight = setLog.Weight,
                });
            }

            return setLostVmList;
        }

        public async Task SaveSet(SetLogViewModel set)
        {
            var setLog = await GetSetLog(set.SetLogId);
            if(setLog != null)
            {
                setLog.Weight = set.Weight;
                setLog.Reps = set.Reps;
                _applicationDbContext.Update(setLog);
                await _applicationDbContext.SaveChangesAsync();
            }  
        }

        public async Task AddNewSetToExercise(int exerciseCarriedOutId)
        {
            var newSet = new SetLog()
            {
                ExerciseCarriedOutId = exerciseCarriedOutId,
                Reps = 0,
                Weight = 0
            };
            await _applicationDbContext.SetLogs.AddAsync(newSet);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteSetLog(int setLogId)
        {
            var setLog = await GetSetLog(setLogId);
            if (setLog != null)
            {
                _applicationDbContext.SetLogs.Remove(setLog);
            }
            await _applicationDbContext.SaveChangesAsync();
        }


        private async Task<SetLog> GetSetLog(int setLogId)
        {
            return await _applicationDbContext.SetLogs.FindAsync(setLogId);
        }

        public async Task<IEnumerable<ExerciseCarriedOut>> GetUsersExerciseHistory(int exTypeId, string appUserId)
        {
            var exerciseCarriedOut = new List<ExerciseCarriedOut>();

            var usersExercises = await _applicationDbContext.ExerciseCarriedOut
                .AsNoTracking()
                .Include(e => e.SetLogs)
                .Where(e => e.ApplicationUserId == appUserId && e.ExerciseTypeId == exTypeId)
                .OrderByDescending(e => e.ExerciseDate)
                .ToListAsync();

            return usersExercises;
        }

        public async Task DeleteExerciseOut(int exCarriedOutId)
        {
            var exerciseCarriedOut = await _applicationDbContext.ExerciseCarriedOut.FindAsync(exCarriedOutId);  
            _applicationDbContext.ExerciseCarriedOut.Remove(exerciseCarriedOut);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
