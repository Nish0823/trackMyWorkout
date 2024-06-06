namespace TrackMyWorkouts.Data.DataModels
{
    public class ExerciseType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public ExerciseType() { }
       
        public ExerciseType(string name)
        {
            Name = name;
        }



        public virtual ICollection<ExerciseTypeCarriedOut> ExercisesCarriedOut { get; set; }
    }
}
