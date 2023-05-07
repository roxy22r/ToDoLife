using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoLife_App.Data;

namespace ToDoLife_App.Models
{
    public class UserProgrammConfigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserProgrammConfigsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserProgrammConfigs
        public async Task<IActionResult> Index()
        {
              return _context.UserProgrammConfig != null ? 
                          View(await _context.UserProgrammConfig.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UserProgrammConfig'  is null.");
        }

        // GET: UserProgrammConfigs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserProgrammConfig == null)
            {
                return NotFound();
            }

            var userProgrammConfig = await _context.UserProgrammConfig
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userProgrammConfig == null)
            {
                return NotFound();
            }

            return View(userProgrammConfig);
        }

        // GET: UserProgrammConfigs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserProgrammConfigs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,createdByUser,filterTodoListDueToday")] UserProgrammConfig userProgrammConfig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProgrammConfig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userProgrammConfig);
        }

        // GET: UserProgrammConfigs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserProgrammConfig == null)
            {
                return NotFound();
            }

            var userProgrammConfig = await _context.UserProgrammConfig.FindAsync(id);
            if (userProgrammConfig == null)
            {
                return NotFound();
            }
            return View(userProgrammConfig);
        }

        // POST: UserProgrammConfigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,createdByUser,filterTodoListDueToday")] UserProgrammConfig userProgrammConfig)
        {
            if (id != userProgrammConfig.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProgrammConfig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProgrammConfigExists(userProgrammConfig.Id))
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
            return View(userProgrammConfig);
        }

        // GET: UserProgrammConfigs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserProgrammConfig == null)
            {
                return NotFound();
            }

            var userProgrammConfig = await _context.UserProgrammConfig
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userProgrammConfig == null)
            {
                return NotFound();
            }

            return View(userProgrammConfig);
        }

        // POST: UserProgrammConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserProgrammConfig == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserProgrammConfig'  is null.");
            }
            var userProgrammConfig = await _context.UserProgrammConfig.FindAsync(id);
            if (userProgrammConfig != null)
            {
                _context.UserProgrammConfig.Remove(userProgrammConfig);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserProgrammConfigExists(int id)
        {
          return (_context.UserProgrammConfig?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
