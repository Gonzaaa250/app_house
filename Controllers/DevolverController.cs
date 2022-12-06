using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app_house.Models;

namespace app_house.Controllers
{
    public class DevolverController : Controller
    {
        private readonly apphouseContext _context;

        public DevolverController(apphouseContext context)
        {
            _context = context;
        }

        // GET: Devolver
        public async Task<IActionResult> Index()
        {
            var apphouseContext = _context.Devolver.Include(d => d.Casa).Include(d => d.Cliente);
            return View(await apphouseContext.ToListAsync());
        }

        // GET: Devolver/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Devolver == null)
            {
                return NotFound();
            }

            var devolver = await _context.Devolver
                .Include(d => d.Casa)
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.Devolverid == id);
            if (devolver == null)
            {
                return NotFound();
            }

            return View(devolver);
        }

        // GET: Devolver/Create
        public IActionResult Create()
        {
            ViewData["Casaid"] = new SelectList(_context.Casa, "Casaid", "Casaname");
            ViewData["Clienteid"] = new SelectList(_context.Cliente, "Clienteid", "Clienteapellido");
            return View();
        }

        // POST: Devolver/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Devolverid,FechaDevolucion,Alquilerid,Clienteid,Casaid,Clientename,Casaname")] Devolver devolver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(devolver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Casaid"] = new SelectList(_context.Casa, "Casaid", "Casaname", devolver.Casaid);
            ViewData["Clienteid"] = new SelectList(_context.Cliente, "Clienteid", "Clienteapellido", devolver.Clienteid);
            return View(devolver);
        }

        // GET: Devolver/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Devolver == null)
            {
                return NotFound();
            }

            var devolver = await _context.Devolver.FindAsync(id);
            if (devolver == null)
            {
                return NotFound();
            }
            ViewData["Casaid"] = new SelectList(_context.Casa, "Casaid", "Casaname", devolver.Casaid);
            ViewData["Clienteid"] = new SelectList(_context.Cliente, "Clienteid", "Clienteapellido", devolver.Clienteid);
            return View(devolver);
        }

        // POST: Devolver/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Devolverid,FechaDevolucion,Alquilerid,Clienteid,Casaid,Clientename,Casaname")] Devolver devolver)
        {
            if (id != devolver.Devolverid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devolver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevolverExists(devolver.Devolverid))
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
            ViewData["Casaid"] = new SelectList(_context.Casa, "Casaid", "Casaname", devolver.Casaid);
            ViewData["Clienteid"] = new SelectList(_context.Cliente, "Clienteid", "Clienteapellido", devolver.Clienteid);
            return View(devolver);
        }

        // GET: Devolver/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Devolver == null)
            {
                return NotFound();
            }

            var devolver = await _context.Devolver
                .Include(d => d.Casa)
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.Devolverid == id);
            if (devolver == null)
            {
                return NotFound();
            }

            return View(devolver);
        }

        // POST: Devolver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Devolver == null)
            {
                return Problem("Entity set 'apphouseContext.Devolver'  is null.");
            }
            var devolver = await _context.Devolver.FindAsync(id);
            if (devolver != null)
            {
                _context.Devolver.Remove(devolver);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevolverExists(int id)
        {
          return (_context.Devolver?.Any(e => e.Devolverid == id)).GetValueOrDefault();
        }
    }
}
