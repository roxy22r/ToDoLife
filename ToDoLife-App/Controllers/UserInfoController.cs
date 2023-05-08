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
            if (null == user.CurrentLevel ) {
                user.CurrentLevel = new Level()
                {
                    LevelNumber = 0,
                    LevelDescription = "Your In The Beginning of Somthing Big",
                    LevelTitle = "ToDoLife Tint Blob State",
                    Points = 0,
                    User = user.Id
                    
                 
                };
            }
             await _context.SaveChangesAsync();
            var nextLevelNr = user.CurrentLevel.LevelNumber + 1;
            var pointToReachNextLevel = _context.Level.Where(l => l.User.Equals(user.Id)).Where(l => l.LevelNumber == nextLevelNr).First();
            var dto = new UserInfoDto()
            {
                Level = user.CurrentLevel,
                CurrentPoints = user.CurrentPoints,
                scoreToReachNextLevel = 1,
                TotalCollectedPoints = user.TotalCollectedPoints,

            };
            return View(dto);
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
