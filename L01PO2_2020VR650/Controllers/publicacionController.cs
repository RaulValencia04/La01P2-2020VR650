using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L01PO2_2020VR650.Models;

namespace L01PO2_2020VR650.Controllers
{
    public class publicacionController : Controller
    {
        private readonly blogDBContexto _context;

        public publicacionController(blogDBContexto context)
        {
            _context = context;
        }

        // GET: publicacion
        public async Task<IActionResult> Index()
        {
              return _context.publicaciones != null ? 
                          View(await _context.publicaciones.ToListAsync()) :
                          Problem("Entity set 'blogDBContexto.publicaciones'  is null.");
        }

        // GET: publicacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.publicaciones == null)
            {
                return NotFound();
            }

            var publicaciones = await _context.publicaciones
                .FirstOrDefaultAsync(m => m.publicacionId == id);
            if (publicaciones == null)
            {
                return NotFound();
            }

            return View(publicaciones);
        }

        // GET: publicacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: publicacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("publicacionId,titulo,descripcion,usuarioId")] Publicaciones publicaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publicaciones);
        }

        // GET: publicacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.publicaciones == null)
            {
                return NotFound();
            }

            var publicaciones = await _context.publicaciones.FindAsync(id);
            if (publicaciones == null)
            {
                return NotFound();
            }
            return View(publicaciones);
        }

        // POST: publicacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("publicacionId,titulo,descripcion,usuarioId")] Publicaciones publicaciones)
        {
            if (id != publicaciones.publicacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacionesExists(publicaciones.publicacionId))
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
            return View(publicaciones);
        }

        // GET: publicacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.publicaciones == null)
            {
                return NotFound();
            }

            var publicaciones = await _context.publicaciones
                .FirstOrDefaultAsync(m => m.publicacionId == id);
            if (publicaciones == null)
            {
                return NotFound();
            }

            return View(publicaciones);
        }

        // POST: publicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.publicaciones == null)
            {
                return Problem("Entity set 'blogDBContexto.publicaciones'  is null.");
            }
            var publicaciones = await _context.publicaciones.FindAsync(id);
            if (publicaciones != null)
            {
                _context.publicaciones.Remove(publicaciones);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicacionesExists(int id)
        {
          return (_context.publicaciones?.Any(e => e.publicacionId == id)).GetValueOrDefault();
        }
    }
}
