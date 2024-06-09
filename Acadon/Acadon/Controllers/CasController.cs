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
using Acadon.ViewModels;

namespace Acadon.Controllers
{
    [Authorize]
    public class CasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cas
        public async Task<IActionResult> Index()
        {
            var casList = await _context.Cas
            .Include(c => c.Predmet)
            .Include(c => c.Razred)
            .Select(c => new CasViewModel
            {
                ID = c.ID,
                PredmetNaziv = c.Predmet.Naziv,
                RazredNaziv = c.Razred.Naziv,
                Vrijeme = c.Vrijeme
            })
            .ToListAsync();
            return View(casList);
        }

        // GET: Cas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cas = await _context.Cas
                .Include(c => c.Predmet)
                .Include(c => c.Razred)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (cas == null)
            {
                return NotFound();
            }

            var viewModel = new CasViewModel
            {
                ID = cas.ID,
                PredmetNaziv = cas.Predmet.Naziv,
                RazredNaziv = cas.Razred.Naziv,
                Vrijeme = cas.Vrijeme
            };

            return View(viewModel);
        }

        // GET: Cas/Create
        public IActionResult Create()
        {
            return View(new CasViewModel());
        }

        // POST: Cas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CasViewModel viewModel)//[Bind("ID,PredmetID,RazredID,Vrijeme")] Cas cas
        {
            if (ModelState.IsValid)
            {
                // Find Predmet by name
                var predmet = await _context.Predmet
                                            .FirstOrDefaultAsync(p => p.Naziv == viewModel.PredmetNaziv);
                if (predmet == null)
                {
                    ModelState.AddModelError("PredmetNaziv", "Predmet not found.");
                    return View(viewModel);
                }

                // Find Razred by name
                var razred = await _context.Razred
                                           .FirstOrDefaultAsync(r => r.Naziv == viewModel.RazredNaziv);
                if (razred == null)
                {
                    ModelState.AddModelError("RazredNaziv", "Razred not found.");
                    return View(viewModel);
                }

                var cas = new Cas
                {
                    PredmetID = predmet.ID,
                    RazredID = razred.ID,
                    Vrijeme = viewModel.Vrijeme
                };

                _context.Add(cas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: Cas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cas = await _context.Cas
                .Include(c => c.Predmet)
                .Include(c => c.Razred)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (cas == null)
            {
                return NotFound();
            }

            var viewModel = new CasViewModel
            {
                ID = cas.ID,
                PredmetNaziv = cas.Predmet.Naziv,
                RazredNaziv = cas.Razred.Naziv,
                Vrijeme = cas.Vrijeme
            };

            return View(viewModel);
        }

        // POST: Cas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CasViewModel viewModel)
        {
            if (id != viewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var predmet = await _context.Predmet
                                                .FirstOrDefaultAsync(p => p.Naziv == viewModel.PredmetNaziv);
                    if (predmet == null)
                    {
                        ModelState.AddModelError("PredmetNaziv", "Predmet not found.");
                        return View(viewModel);
                    }

                    var razred = await _context.Razred
                                               .FirstOrDefaultAsync(r => r.Naziv == viewModel.RazredNaziv);
                    if (razred == null)
                    {
                        ModelState.AddModelError("RazredNaziv", "Razred not found.");
                        return View(viewModel);
                    }

                    var cas = await _context.Cas.FindAsync(id);
                    cas.PredmetID = predmet.ID;
                    cas.RazredID = razred.ID;
                    cas.Vrijeme = viewModel.Vrijeme;

                    _context.Update(cas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasExists(viewModel.ID))
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
            return View(viewModel);
        }

        // GET: Cas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cas = await _context.Cas
                .Include(c => c.Predmet)
                .Include(c => c.Razred)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (cas == null)
            {
                return NotFound();
            }

            var viewModel = new CasViewModel
            {
                ID = cas.ID,
                PredmetNaziv = cas.Predmet.Naziv,
                RazredNaziv = cas.Razred.Naziv,
                Vrijeme = cas.Vrijeme
            };

            return View(viewModel);
        }

        // POST: Cas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cas = await _context.Cas.FindAsync(id);
            _context.Cas.Remove(cas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasExists(int id)
        {
            return _context.Cas.Any(e => e.ID == id);
        }
    }
}
