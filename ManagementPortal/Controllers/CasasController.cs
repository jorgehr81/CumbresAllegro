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
    public class CasasController : Controller
    {
        private readonly AdminContext _context;

        public CasasController(AdminContext context)
        {
            _context = context;
        }

        // GET: Casas
        public async Task<IActionResult> Index()
        {
            ViewBag.Calles = _context.Calles.ToList();
            return View(await _context.Casas.ToListAsync());
        }

        // GET: Casas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casa = await _context.Casas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casa == null)
            {
                return NotFound();
            }

            return View(casa);
        }

        // GET: Casas/Create
        public IActionResult Create()
        {
            ViewBag.Calles = _context.Calles.ToList();
            return View();
        }

        // POST: Casas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CalleId,Numero,NombrePropietario,Correo,Telefono1,Telefono2,Telefono3,AccesoCamaras")] Casa casa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casa);
        }

        // GET: Casas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casa = await _context.Casas.FindAsync(id);
            if (casa == null)
            {
                return NotFound();
            }

            ViewBag.Calles = _context.Calles.ToList();
            return View(casa);
        }

        // POST: Casas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CalleId,Numero,NombrePropietario,Correo,Telefono1,Telefono2,Telefono3,AccesoCamaras")] Casa casa)
        {
            if (id != casa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasaExists(casa.Id))
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
            return View(casa);
        }

        // GET: Casas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casa = await _context.Casas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casa == null)
            {
                return NotFound();
            }

            return View(casa);
        }

        // POST: Casas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casa = await _context.Casas.FindAsync(id);
            _context.Casas.Remove(casa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasaExists(int id)
        {
            return _context.Casas.Any(e => e.Id == id);
        }
    }
}
