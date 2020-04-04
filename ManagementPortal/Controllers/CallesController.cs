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
    public class CallesController : Controller
    {
        private readonly AdminContext _context;

        public CallesController(AdminContext context)
        {
            _context = context;
        }

        // GET: Calles
        public async Task<IActionResult> Index()
        {
            ViewBag.Colonias = _context.Colonia.ToList();
            return View(await _context.Calles.ToListAsync());
        }

        // GET: Calles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calle = await _context.Calles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calle == null)
            {
                return NotFound();
            }

            return View(calle);
        }

        // GET: Calles/Create
        public IActionResult Create()
        {
            ViewBag.Colonias = _context.Colonia.ToList();
            return View();
        }

        // POST: Calles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,ColoniaId,Referencia")] Calle calle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calle);
        }

        // GET: Calles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calle = await _context.Calles.FindAsync(id);
            if (calle == null)
            {
                return NotFound();
            }

            ViewBag.Colonias = _context.Colonia.ToList();
            return View(calle);
        }

        // POST: Calles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,ColoniaId,Referencia")] Calle calle)
        {
            if (id != calle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalleExists(calle.Id))
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
            return View(calle);
        }

        // GET: Calles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calle = await _context.Calles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calle == null)
            {
                return NotFound();
            }

            return View(calle);
        }

        // POST: Calles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calle = await _context.Calles.FindAsync(id);
            _context.Calles.Remove(calle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalleExists(int id)
        {
            return _context.Calles.Any(e => e.Id == id);
        }
    }
}
