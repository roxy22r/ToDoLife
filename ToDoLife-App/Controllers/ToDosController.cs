using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoLife_App.Areas;
using ToDoLife_App.Data;
using ToDoLife_App.Models;

namespace ToDoLife_App.Controllers
{
    [Authorize]
    public class ToDosController : Controller
    {
        private ApplicationUserService _service;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private bool isFilterOn = false;

        public ToDosController(ApplicationDbContext context, IConfiguration configuration,
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


        }
        // GET: ToDos
        public async Task<IActionResult> Index()
        {
            intUser();

            if (_context.ToDo != null ) {

                if (isFilterOn) {
                    var todo = getTodosOfUser().Where(todo => todo.DueDate.Day.Equals(DateTime.Now.Day));
                 return   View(todo);
                }
                else
                {
                    return View(getTodosOfUser());

                }
            }
            else
            {
                return Problem("Entity set 'ApplicationDbContext.ToDo'  is null.");

            }
        }
    

        private IQueryable<ToDo> getTodosOfUser() {
            return _context.ToDo.Where(todo => todo.createdByUser.Equals(_service.ApplicationUser.Id));
        }

        // GET: ToDos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ToDo == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // GET: ToDos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,DueDate,Points")] ToDo toDo)
        {
            intUser();

            if (ModelState.IsValid)
            {
                toDo.createdByUser = _service.ApplicationUser.Id;
                _context.Add(toDo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDo);
        }

        // GET: ToDos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ToDo == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDo.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return View(toDo);
        }

        // POST: ToDos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,DueDate,Points")] ToDo toDo)
        {
            intUser();
            if (id != toDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    toDo.createdByUser = _service.ApplicationUser.Id;
                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(toDo);
        }

        // GET: ToDos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ToDo == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // POST: ToDos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ToDo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ToDo'  is null.");
            }
            var toDo = await _context.ToDo.FindAsync(id);
            if (toDo != null)
            {
                _context.ToDo.Remove(toDo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoExists(int id)
        {
          return (_context.ToDo?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        [HttpPost, ActionName("setTaskCompleted")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> setTaskCompleted(int? Id)
        {
            intUser();
            ToDo todo = await _context.ToDo.FindAsync(Id);
            todo.IsCompleted = !todo.IsCompleted;
            if (null != todo.Points)
            {
                int points = (int)(todo.Points);
                if (todo.IsCompleted)
                {
                   _service.addPoints(points);
                }
                else
                {
                    _service.subtractPoints(points);
                }
            }
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("FilterByDone")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FilterByDone()
        {
          this.isFilterOn = !isFilterOn;
         
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
