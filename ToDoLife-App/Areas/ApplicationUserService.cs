using Microsoft.AspNetCore.Identity;
using ToDoLife_App.Areas;
using ToDoLife_App.Data;

namespace ToDoLife_App.Areas
{
    /*
     * WebPage info to get current user in ASP .Net MVC application
     * https://codewithmukesh.com/blog/user-management-in-aspnet-core-mvc/
    */
    public class ApplicationUserService
    {
        private ApplicationUser _appUser;
        private readonly ApplicationUser readOnlyUser;


        public ApplicationUserService(ApplicationUser user)
        {
            _appUser = user;
            readOnlyUser = user;

        }

        public ApplicationUser ApplicationUser { get => readOnlyUser; }
        public void addPoints(int points)
        {
           _appUser.CurrentPoints += points;
           _appUser.TotalCollectedPoints += points;
            
        }

        public void subtractPoints(int points)
        {
            _appUser.CurrentPoints -= points;
            _appUser.TotalCollectedPoints -= points;
        }
    }
}
