using ToDoLife_App.Controllers.Levels;
using ToDoLife_App.Data;
using ToDoLife_App.Models;

namespace ToDoLife_App.Controllers.Prices
{
    public class GeneratedPrice
    {
        public static void generatePrices(ApplicationDbContext context, Guid user)
        {
            for (int level = 1; level <= 100; level++)
            {
                Price initPrice = new Price()
                {
                   User = user,
                   Description= "",
                   Title="",
                   Level = GenerateLevels.generateLevel(context,user,level) ,
                    
                };
                context.Add(initPrice);
                context.SaveChanges();
            }
    }
}
}
