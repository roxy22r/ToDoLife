using Microsoft.AspNetCore.Identity;
using ToDoLife_App.Models;

namespace ToDoLife_App.Areas
{
    public class ApplicationUser : IdentityUser
    {
        public string? Username { get; set; }
        public int TotalCollectedPoints { get; set; }
        public Level? CurrentLevel { get; set; }
        public int CurrentPoints { get; set; }
        
    }
}
