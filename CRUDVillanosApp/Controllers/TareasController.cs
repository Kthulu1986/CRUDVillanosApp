using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRUDVillanosApp.Controllers
{
    public class TareasController : Controller
    {
        private readonly MyIndiminContext _context;

        public TareasController(MyIndiminContext context)
        {
            _context = context;
        }

        // GET: Tareas
        public async Task<IActionResult> Index()
        {
            var myIndiminContext = _context.Tareas.Include(t => t.Ciudadano);
            return View(await myIndiminContext.ToListAsync());
        }

        // GET: Tareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tareas == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tareas
                .Include(t => t.Ciudadano)
                .FirstOrDefaultAsync(m => m.id == id);
            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        // GET: Tareas/Create
        public IActionResult Create()
        {
            ViewData["IdCiudadano"] = new SelectList(_context.Ciudadanos, "id", "Nombre");
            return View();
        }

        // POST: Tareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nombre,IdCiudadano,dia")] Tarea tarea)
        {
            //var asdf = ModelState.Values.Where(v => v.Errors.Count > 0);
            if (ModelState.IsValid)
            {
                _context.Add(tarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            ViewData["IdCiudadano"] = new SelectList(_context.Ciudadanos, "id", "id", tarea.IdCiudadano);
            return View(tarea);
        }

        // GET: Tareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tareas == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }
            ViewData["IdCiudadano"] = new SelectList(_context.Ciudadanos, "id", "id", tarea.IdCiudadano);
            return View(tarea);
        }

        // POST: Tareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nombre,IdCiudadano")] Tarea tarea)
        {
            if (id != tarea.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TareaExists(tarea.id))
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
            ViewData["IdCiudadano"] = new SelectList(_context.Ciudadanos, "id", "id", tarea.IdCiudadano);
            return View(tarea);
        }

        // GET: Tareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tareas == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tareas
                .Include(t => t.Ciudadano)
                .FirstOrDefaultAsync(m => m.id == id);
            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tareas == null)
            {
                return Problem("Entity set 'MyIndiminContext.Tareas'  is null.");
            }
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TareaExists(int id)
        {
          return _context.Tareas.Any(e => e.id == id);
        }
    }
}
