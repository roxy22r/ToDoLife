using ToDoLife_App.Controllers.Levels;
using ToDoLife_App.Data;
using ToDoLife_App.Models;

namespace ToDoLife_App.Controllers.Prices
{
    public class GeneratedPrice
    {
        public static void generatePrices(ApplicationDbContext context, Guid user)
        {
            for (int levelNr = 1; levelNr <= 100; levelNr++)
            {
                Level level = GenerateLevels.generateLevel(context, user, levelNr);
                Price initPrice = new Price()
                {
                    User = user,
                    Description = "",
                    Title = "",
                    Level = level,

                };
                if (levelNr == 1)
                {
                    var userToSetLevel = context.Users.Where(u => u.Id.Equals(user)).First();
                    userToSetLevel.CurrentLevel = level;
                }
                context.Add(initPrice);
                context.SaveChanges();
            }
        }
    }
}
