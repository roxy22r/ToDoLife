using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoLife_App.Areas;
using ToDoLife_App.Models;

namespace ToDoLife_App.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<ToDoLife_App.Models.ToDo>? ToDo { get; set; }
        public DbSet<ToDoLife_App.Models.Level>? Level { get; set; }
        public DbSet<ToDoLife_App.Models.Price>? Price { get; set; }
        public DbSet<ToDoLife_App.Models.UserProgrammConfig>? UserProgrammConfig { get; set; }
    }
}