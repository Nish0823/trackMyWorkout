using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrackMyWorkouts.Data.DataModels;

namespace TrackMyWorkouts.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ExerciseType> ExerciseType { get; set; }
        public DbSet<ExerciseCarriedOut> ExerciseCarriedOut { get; set; }

        public DbSet<ExerciseTypeCarriedOut> ExerciseTypeCarriedOut { get; set; }

        public DbSet<SetLog> SetLogs { get; set; }
    }
}
