using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRUDVillanosApp.Controllers
{
    public class CiudadanoController : Controller
    {
        private readonly MyIndiminContext _context;

        public CiudadanoController(MyIndiminContext context)
        {
            _context = context;
        }

        // GET: Ciudadano
        public async Task<IActionResult> Index(string buscar)
        {
            var ciudadanos = from Nombre in _context.Ciudadanos select Nombre;

            if (!String.IsNullOrEmpty(buscar))
            {
                ciudadanos = ciudadanos.Where(s => s.Nombre!.Contains(buscar));
            }



            return View(await ciudadanos.ToListAsync());
        }

        // GET: Ciudadano/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ciudadanos == null)
            {
                return NotFound();
            }

            var ciudadano = await _context.Ciudadanos
                .FirstOrDefaultAsync(m => m.id == id);
            if (ciudadano == null)
            {
                return NotFound();
            }

            return View(ciudadano);
        }

        // GET: Ciudadano/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ciudadano/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nombre,Edad")] Ciudadano ciudadano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciudadano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ciudadano);
        }

        // GET: Ciudadano/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ciudadanos == null)
            {
                return NotFound();
            }

            var ciudadano = await _context.Ciudadanos.FindAsync(id);
            if (ciudadano == null)
            {
                return NotFound();
            }
            return View(ciudadano);
        }

        // POST: Ciudadano/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nombre,Edad")] Ciudadano ciudadano)
        {
            if (id != ciudadano.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciudadano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiudadanoExists(ciudadano.id))
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
            return View(ciudadano);
        }

        // GET: Ciudadano/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ciudadanos == null)
            {
                return NotFound();
            }

            var ciudadano = await _context.Ciudadanos
                .FirstOrDefaultAsync(m => m.id == id);
            if (ciudadano == null)
            {
                return NotFound();
            }

            return View(ciudadano);
        }

        // POST: Ciudadano/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ciudadanos == null)
            {
                return Problem("Entity set 'MyIndiminContext.Ciudadanos'  is null.");
            }
            var ciudadano = await _context.Ciudadanos.FindAsync(id);
            if (ciudadano != null)
            {
                _context.Ciudadanos.Remove(ciudadano);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiudadanoExists(int id)
        {
            return _context.Ciudadanos.Any(e => e.id == id);
        }
    }
}
