using ToDoLife_App.Data;
using ToDoLife_App.Models;

namespace ToDoLife_App.Controllers.Levels
{
    public class GenerateLevels
    {
        public static void generateLevels(ApplicationDbContext context, Guid user)
        {
            for (int level = 1; level <= 100; level++)
            {
                Level initLevel = new Level()
                {
                    LevelNumber = level,
                    LevelTitle = level.ToString(),
                    Points = level * 20 + 23,
                    User = user,
                    LevelDescription = "",
                };
                context.Add(initLevel);
                context.SaveChanges();
            }
        }

        public static Level generateLevel(ApplicationDbContext context, Guid user, int levelNr)
        {
            Level initLevel = new Level()
            {
                LevelNumber = levelNr,
                LevelTitle = levelNr.ToString(),
                Points = levelNr * 20 + 23,
                User = user,
                LevelDescription = "",
            };
            context.Add(initLevel);
            context.SaveChanges();
            return initLevel;

        }
    }
}
