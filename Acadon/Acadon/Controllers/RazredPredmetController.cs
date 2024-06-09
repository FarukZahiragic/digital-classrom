using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Acadon.Data;
using Acadon.Models;
using Microsoft.AspNetCore.Authorization;

namespace Acadon.Controllers
{
    [Authorize]
    public class RazredPredmetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RazredPredmetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RazredPredmet
        public async Task<IActionResult> Index()
        {
            return View(await _context.RazredPredmet.ToListAsync());
        }

        // GET: RazredPredmet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razredPredmet = await _context.RazredPredmet
                .FirstOrDefaultAsync(m => m.ID == id);
            if (razredPredmet == null)
            {
                return NotFound();
            }

            return View(razredPredmet);
        }

        // GET: RazredPredmet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RazredPredmet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RazredID,PredmetID")] RazredPredmet razredPredmet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(razredPredmet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(razredPredmet);
        }

        // GET: RazredPredmet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razredPredmet = await _context.RazredPredmet.FindAsync(id);
            if (razredPredmet == null)
            {
                return NotFound();
            }
            return View(razredPredmet);
        }

        // POST: RazredPredmet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RazredID,PredmetID")] RazredPredmet razredPredmet)
        {
            if (id != razredPredmet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(razredPredmet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RazredPredmetExists(razredPredmet.ID))
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
            return View(razredPredmet);
        }

        // GET: RazredPredmet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razredPredmet = await _context.RazredPredmet
                .FirstOrDefaultAsync(m => m.ID == id);
            if (razredPredmet == null)
            {
                return NotFound();
            }

            return View(razredPredmet);
        }

        // POST: RazredPredmet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var razredPredmet = await _context.RazredPredmet.FindAsync(id);
            if (razredPredmet != null)
            {
                _context.RazredPredmet.Remove(razredPredmet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RazredPredmetExists(int id)
        {
            return _context.RazredPredmet.Any(e => e.ID == id);
        }
    }
}
