using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FestivallWeb.Data;
using FestivallWeb.Models;

namespace FestivallWeb.Controllers
{
    public class GroupesController : Controller
    {
        private readonly FestivallWebContext _context;

        public GroupesController(FestivallWebContext context)
        {
            _context = context;
        }

        // GET: Groupes
        public async Task<IActionResult> Index()
        {
              return _context.Groupe != null ? 
                          View(await _context.Groupe.ToListAsync()) :
                          Problem("Entity set 'FestivallWebContext.Groupe'  is null.");
        }

        // GET: Groupes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Groupe == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupe == null)
            {
                return NotFound();
            }

            return View(groupe);
        }

        // GET: Groupes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groupes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Groupe groupeVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupeVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupeVM);
        }

        // GET: Groupes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Groupe == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupe.FindAsync(id);
            if (groupe == null)
            {
                return NotFound();
            }
            return View(groupe);
        }

        // POST: Groupes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Groupe groupeVM)
        {
            if (id != groupeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupeVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupeExists(groupeVM.Id))
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
            return View(groupeVM);
        }

        // GET: Groupes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Groupe == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupe == null)
            {
                return NotFound();
            }

            return View(groupe);
        }

        // POST: Groupes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Groupe == null)
            {
                return Problem("Entity set 'FestivallWebContext.Groupe'  is null.");
            }
            var groupe = await _context.Groupe.FindAsync(id);
            if (groupe != null)
            {
                _context.Groupe.Remove(groupe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupeExists(int id)
        {
          return (_context.Groupe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
