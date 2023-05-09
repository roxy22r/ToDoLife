using ToDoLife_App.Models;

namespace ToDoLife_App.Areas
{
    public class UserInfoDto
    {
        public int TotalCollectedPoints { get; set; }
        public Level Level { get; set; }
        public int scoreToReachNextLevel { get; set; }
        public int CurrentPoints { get; set; }
        public int scoreToReachNextLevelProcentage { get; set; }


    }
}
