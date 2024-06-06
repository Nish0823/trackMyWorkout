using Microsoft.AspNetCore.Identity;

namespace TrackMyWorkouts.Data.DataModels
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
