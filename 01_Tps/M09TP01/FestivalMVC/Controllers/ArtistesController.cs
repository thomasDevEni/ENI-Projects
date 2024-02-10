using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FestivallWeb.Data;
using FestivallWeb.Models;
using FestivallWeb.ViewModels;

namespace FestivallWeb.Controllers
{
    public class ArtistesController : Controller
    {
        private readonly FestivallWebContext _context;

        public ArtistesController(FestivallWebContext context)
        {
            _context = context;
        }

        // GET: Artistes
        public async Task<IActionResult> Index()
        {
            var festivallWebContext = _context.Artiste.Include(a => a.Groupe);
            return View(await festivallWebContext.ToListAsync());
        }

        // GET: Artistes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artiste == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artiste
                .Include(a => a.Groupe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artiste == null)
            {
                return NotFound();
            }

            return View(artiste);
        }

        // GET: Artistes/Create
        public IActionResult Create()
        {
            ViewData["GroupeId"] = new SelectList(_context.Set<Models.Groupe>(), "Id", "Id");
            return View();
        }

        // POST: Artistes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtisteViewModel artisteVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artisteVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupeId"] = new SelectList(_context.Set<Models.Groupe>(), "Id", "Id", artisteVM.GroupeId);
            return View(artisteVM);
        }

        // GET: Artistes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artiste == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artiste.FindAsync(id);
            if (artiste == null)
            {
                return NotFound();
            }
            ViewData["GroupeId"] = new SelectList(_context.Set<Models.Groupe>(), "Id", "Id", artiste.GroupeId);
            return View(artiste);
        }

        // POST: Artistes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArtisteViewModel artisteVM)
        {
            if (id != artisteVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artisteVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtisteExists(artisteVM.Id))
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
            ViewData["GroupeId"] = new SelectList(_context.Set<Models.Groupe>(), "Id", "Id", artisteVM.GroupeId);
            return View(artisteVM);
        }

        // GET: Artistes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artiste == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artiste
                .Include(a => a.Groupe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artiste == null)
            {
                return NotFound();
            }

            return View(artiste);
        }

        // POST: Artistes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artiste == null)
            {
                return Problem("Entity set 'FestivallWebContext.Artiste'  is null.");
            }
            var artiste = await _context.Artiste.FindAsync(id);
            if (artiste != null)
            {
                _context.Artiste.Remove(artiste);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtisteExists(int id)
        {
          return (_context.Artiste?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
