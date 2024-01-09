﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoCRUDEntityFramework.Data;
using DemoCRUDEntityFramework.Models;

namespace DemoCRUDEntityFramework.Controllers
{
    public class EtudiantsController : Controller
    {
        private readonly DemoCRUDEntityFrameworkContext _context;

        public EtudiantsController(DemoCRUDEntityFrameworkContext context)
        {
            _context = context;
        }

        // GET: Etudiants
        public async Task<IActionResult> Index()
        {
              return _context.Etudiant != null ? 
                          View(await _context.Etudiant.ToListAsync()) :
                          Problem("Entity set 'DemoCRUDEntityFrameworkContext.Etudiant'  is null.");
        }

        // GET: Etudiants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Etudiant == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // GET: Etudiants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etudiants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Niveau")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etudiant);
        }

        // GET: Etudiants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Etudiant == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiant.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }
            return View(etudiant);
        }

        // POST: Etudiants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Niveau")] Etudiant etudiant)
        {
            if (id != etudiant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etudiant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtudiantExists(etudiant.Id))
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
            return View(etudiant);
        }

        // GET: Etudiants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Etudiant == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // POST: Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Etudiant == null)
            {
                return Problem("Entity set 'DemoCRUDEntityFrameworkContext.Etudiant'  is null.");
            }
            var etudiant = await _context.Etudiant.FindAsync(id);
            if (etudiant != null)
            {
                _context.Etudiant.Remove(etudiant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtudiantExists(int id)
        {
          return (_context.Etudiant?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
