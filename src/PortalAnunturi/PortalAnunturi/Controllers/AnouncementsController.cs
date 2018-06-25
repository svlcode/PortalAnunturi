using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalAnunturi.Models;
using PortalAnunturi.Models.Entities;

namespace PortalAnunturi.Controllers
{
    public class AnouncementsController : Controller
    {
        private readonly AnouncementsDbContext _context;

        public AnouncementsController(AnouncementsDbContext context)
        {
            _context = context;
        }

        // GET: Anouncements
        public async Task<IActionResult> Index()
        {
            var anouncementsDbContext = _context.Anouncement.Include(a => a.CategoryNavigation).Include(a => a.UserNavigation);
            return View(await anouncementsDbContext.ToListAsync());
        }

        // GET: Anouncements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anouncement = await _context.Anouncement
                .Include(a => a.CategoryNavigation)
                .Include(a => a.UserNavigation)
                .FirstOrDefaultAsync(m => m.IdAnouncement == id);
            if (anouncement == null)
            {
                return NotFound();
            }

            return View(anouncement);
        }

        // GET: Anouncements/Create
        public IActionResult Create()
        {
            ViewData["Category"] = new SelectList(_context.Category, "IdCategory", "IdCategory");
            ViewData["User"] = new SelectList(_context.User, "IdUser", "IdUser");
            return View();
        }

        // POST: Anouncements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAnouncement,Title,Description,CreationDate,ExpirationDate,Category,User")] Anouncement anouncement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anouncement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category"] = new SelectList(_context.Category, "IdCategory", "IdCategory", anouncement.Category);
            ViewData["User"] = new SelectList(_context.User, "IdUser", "IdUser", anouncement.User);
            return View(anouncement);
        }

        // GET: Anouncements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anouncement = await _context.Anouncement.FindAsync(id);
            if (anouncement == null)
            {
                return NotFound();
            }
            ViewData["Category"] = new SelectList(_context.Category, "IdCategory", "IdCategory", anouncement.Category);
            ViewData["User"] = new SelectList(_context.User, "IdUser", "IdUser", anouncement.User);
            return View(anouncement);
        }

        // POST: Anouncements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnouncement,Title,Description,CreationDate,ExpirationDate,Category,User")] Anouncement anouncement)
        {
            if (id != anouncement.IdAnouncement)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anouncement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnouncementExists(anouncement.IdAnouncement))
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
            ViewData["Category"] = new SelectList(_context.Category, "IdCategory", "IdCategory", anouncement.Category);
            ViewData["User"] = new SelectList(_context.User, "IdUser", "IdUser", anouncement.User);
            return View(anouncement);
        }

        // GET: Anouncements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anouncement = await _context.Anouncement
                .Include(a => a.CategoryNavigation)
                .Include(a => a.UserNavigation)
                .FirstOrDefaultAsync(m => m.IdAnouncement == id);
            if (anouncement == null)
            {
                return NotFound();
            }

            return View(anouncement);
        }

        // POST: Anouncements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anouncement = await _context.Anouncement.FindAsync(id);
            _context.Anouncement.Remove(anouncement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnouncementExists(int id)
        {
            return _context.Anouncement.Any(e => e.IdAnouncement == id);
        }
    }
}
