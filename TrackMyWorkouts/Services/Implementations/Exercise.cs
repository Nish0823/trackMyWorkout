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
            var newExerciseCarriedOut = new ExerciseCarriedOut() { ExerciseDate = currentDate, ApplicationUserId = appUserId };
            await _applicationDbContext.ExerciseCarriedOut.AddAsync(newExerciseCarriedOut);
            await _applicationDbContext.SaveChangesAsync();
            await CreateNewExTypeCarriedOut(newExerciseCarriedOut.Id, exTypeId);
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

        public async Task<IEnumerable<ExerciseTypeCarriedOut>> GetUsersExercisesForThisDate(DateTime utcNow, string appUserId)
        {
            DateTime searchDate = utcNow.Date;
            var exercises = await _applicationDbContext.ExerciseCarriedOut
                                                .AsNoTracking()
                                                .Where(e => e.ExerciseDate == searchDate && e.ApplicationUserId == appUserId).ToListAsync();
                                                
            var exTypeCarriedOutList = new List<ExerciseTypeCarriedOut>();

            foreach (var exercise in exercises)
            {
                var exTypeCarriedOut = await _applicationDbContext.ExerciseTypeCarriedOut
                    .AsNoTracking()
                    .Include(e => e.ExerciseType)
                    .FirstOrDefaultAsync(e => e.ExerciseCarriedOutId == exercise.Id);

                if(exTypeCarriedOut != null)
                {
                    exTypeCarriedOutList.Add(exTypeCarriedOut);
                }
            }
            return exTypeCarriedOutList;
        }

        private async Task CreateNewExTypeCarriedOut(int exCarriedoutId, int exTypeId)
        {
            var newExTypeCarriedOut = new ExerciseTypeCarriedOut()
            {
                ExerciseCarriedOutId = exCarriedoutId,
                ExerciseTypeId = exTypeId
            };

            await _applicationDbContext.ExerciseTypeCarriedOut.AddAsync(newExTypeCarriedOut);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkoutLogViewModel>> WorkoutLogViewModelsList(DateTime date, string appUserId)
        {
            List<WorkoutLogViewModel> workoutLogViewModels = new List<WorkoutLogViewModel>();

            var exTypeCarriedOut = await GetUsersExercisesForThisDate(date, appUserId);

            foreach (var workOutLog in exTypeCarriedOut)
            {
                var newVm = new WorkoutLogViewModel()
                {
                    ExerciseCarriedOutId = workOutLog.ExerciseCarriedOutId,
                    ExerciseName = workOutLog.ExerciseType.Name,
                    ExerciseTypeId = workOutLog.ExerciseTypeId,
                    SetLogs = await GetSetLogsViewModel(workOutLog.ExerciseCarriedOutId),
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
            var exerciseTypeCarriedOut = await _applicationDbContext.ExerciseTypeCarriedOut.Where(ex => ex.ExerciseTypeId == exTypeId).ToListAsync();

            var usersEvercises = _applicationDbContext.ExerciseCarriedOut
                .AsNoTracking()
                .Include(e => e.SetLogs)
                .Where(e => e.ApplicationUserId == appUserId)
                .OrderByDescending(e => e.ExerciseDate)
                .ToDictionary(e => e.Id, e => e);

            foreach(var ex in exerciseTypeCarriedOut)
            {
                if(usersEvercises.TryGetValue(ex.ExerciseCarriedOutId, out ExerciseCarriedOut value))
                {
                    exerciseCarriedOut.Add(value);
                }
            }

            return exerciseCarriedOut;
        }
    }
}
