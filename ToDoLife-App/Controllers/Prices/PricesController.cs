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
using ToDoLife_App.Controllers.Prices;
using ToDoLife_App.Data;
using ToDoLife_App.Models;

namespace ToDoLife_App.Controllers
{
    [Authorize]
    public class PricesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ApplicationUserService _service;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        public PricesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _config = config;
            _userManager = userManager;
            _context = context;
        }
        private void intUser()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            _service = new ApplicationUserService(user.Result);

        }

        // GET: Prices
        public async Task<IActionResult> Index()
        {
            intUser();
            if (!_context.Price.Any(p=>p.User.Equals(_service.ApplicationUser.Id))) {
                GeneratedPrice.generatePrices(_context, _service.ApplicationUser.Id);
            }
            List<Price> prices = await _context.Price.Include(p => p.Level).Where(p => p.User.Equals(_service.ApplicationUser.Id)).ToListAsync();
        
            
              return _context.Price != null ? 
                          View(prices) :
                          Problem("Entity set 'ApplicationDbContext.Price'  is null.");
        }

        // GET: Prices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Price == null)
            {
                return NotFound();
            }

            var price = await _context.Price
                .FirstOrDefaultAsync(m => m.Id == id);
            if (price == null)
            {
                return NotFound();
            }

            return View(price);
        }

        // GET: Prices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Price price)
        {
            if (ModelState.IsValid)
            {
                _context.Add(price);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(price);
        }

        // GET: Prices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Price == null)
            {
                return NotFound();
            }

            Price price = await _context.Price.Include(p=>p.Level).Where(p=>p.Id==id).FirstAsync();

            if (price == null)
            {
                return NotFound();
            }
            return View(price);
        }

        // POST: Prices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Price price)
        {
            intUser();

            if (id != price.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Level");
            if (ModelState.IsValid)
            {
                try
                {
                    price.User=_service.ApplicationUser.Id;
                    _context.Price.Update(price);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceExists(price.Id))
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
            return View(price);
        }

        // GET: Prices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Price == null)
            {
                return NotFound();
            }

            var price = await _context.Price
                .FirstOrDefaultAsync(m => m.Id == id);
            if (price == null)
            {
                return NotFound();
            }

            return View(price);
        }

        // POST: Prices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Price == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Price'  is null.");
            }
            var price = await _context.Price.FindAsync(id);
            if (price != null)
            {
                _context.Price.Remove(price);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PriceExists(int id)
        {
          return (_context.Price?.Any(e => e.Id == id)).GetValueOrDefault();
        }
       
    }
}
