using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CumbreAllegro2.Data;
using CumbreAllegro2.Models;

namespace CumbreAllegro2.Controllers
{
    public class ColoniasController : Controller
    {
        private readonly AdminContext _context;

        public ColoniasController(AdminContext context)
        {
            _context = context;
        }

        // GET: Colonias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Colonia.ToListAsync());
        }

        // GET: Colonias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colonia = await _context.Colonia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colonia == null)
            {
                return NotFound();
            }

            return View(colonia);
        }

        // GET: Colonias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colonias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Sector,CodigoPostal")] Colonia colonia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colonia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colonia);
        }

        // GET: Colonias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colonia = await _context.Colonia.FindAsync(id);
            if (colonia == null)
            {
                return NotFound();
            }
            return View(colonia);
        }

        // POST: Colonias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Sector,CodigoPostal")] Colonia colonia)
        {
            if (id != colonia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colonia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColoniaExists(colonia.Id))
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
            return View(colonia);
        }

        // GET: Colonias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colonia = await _context.Colonia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colonia == null)
            {
                return NotFound();
            }

            return View(colonia);
        }

        // POST: Colonias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colonia = await _context.Colonia.FindAsync(id);
            _context.Colonia.Remove(colonia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColoniaExists(int id)
        {
            return _context.Colonia.Any(e => e.Id == id);
        }
    }
}
