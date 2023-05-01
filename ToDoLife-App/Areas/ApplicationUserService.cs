namespace ToDoLife_App.Areas
{
    /*
     * WebPage info to get current user in ASP .Net MVC application
     * https://codewithmukesh.com/blog/user-management-in-aspnet-core-mvc/
    */
    public class ApplicationUserService
    {
        private ApplicationUser appUser = new ApplicationUser();
        public void addPoints(int points)
        {
            appUser.CurrentPoints += points;
            appUser.TotalCollectedPoints += points;
            
        }
    }
}
