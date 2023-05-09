using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoLife_App.Areas;
using ToDoLife_App.Controllers.UserProgammConfig;
using ToDoLife_App.Data;
using ToDoLife_App.Models;

namespace ToDoLife_App.Controllers
{
    public class UserInfoController : Controller
    {
        private ApplicationUserService _service;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private ServiceUserProgrammConfig userConfig;

        public UserInfoController(ApplicationDbContext context, IConfiguration configuration,
        UserManager<ApplicationUser> userManager)
        {
            _config = configuration;
            _userManager = userManager;
            _context = context;
        }

        private void intUser()
        {
            var connectionstring = _config.GetConnectionString("DefaultConnection");
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            _service = new ApplicationUserService(user.Result);
            userConfig = new ServiceUserProgrammConfig(_context, user.Result.Id);

        }
        // GET: UserController
        public async Task<IActionResult> Index()
        {
            intUser();
            var user = _service.ApplicationUser;
            initLevelZero(user);
            while (isNextLevelReached(user)) { 
            scaleLevelIfNeeded(user);
            }
            var scoreToReachNextLevel = getNextLevel(user).Points;
            var procentage = getProzentageOfReachingLevel(scoreToReachNextLevel, user);
            var dto = new UserInfoDto()
            {
                Level = user.CurrentLevel,
                CurrentPoints = user.CurrentPoints,
                scoreToReachNextLevel = scoreToReachNextLevel,
                TotalCollectedPoints = user.TotalCollectedPoints,
                scoreToReachNextLevelProcentage = procentage

            };
            return View(dto);
        }
        private int getProzentageOfReachingLevel(int scoreToReachNextLevel,ApplicationUser user) {
           return (int)Math.Round((100/(double)scoreToReachNextLevel ) * (double)user.TotalCollectedPoints);
        } 
        private bool isNextLevelReached(ApplicationUser user) {
            var pointsToGetNextLevel = getNextLevel(user).Points;
        return  0>=(pointsToGetNextLevel- user.TotalCollectedPoints);
        }
        private  void initLevelZero(ApplicationUser user) {
            if (null == user.CurrentLevel)
            {
                user.CurrentLevel = new Level()
                {
                    LevelNumber = 0,
                    LevelDescription = "Your In The Beginning of Somthing Big",
                    LevelTitle = "ToDoLife Tiny Blob State",
                    Points = 0,
                    User = user.Id


                };
                 _context.SaveChanges();

            }
        }
        private  void scaleLevelIfNeeded(ApplicationUser user) {
            if (isNextLevelReached(user))
            {
                user.CurrentLevel = getNextLevel(user);
                 _context.SaveChanges();

            }

        }

        private Level getNextLevel(ApplicationUser user) {
            return _context.Level.Where(l => l.User.Equals(user.Id)).Where(l => l.LevelNumber == (user.CurrentLevel.LevelNumber + 1)).First();
        }
        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
