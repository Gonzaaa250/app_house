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
    public class AlquilerController : Controller
    {
        private readonly apphouseContext _context;

        public AlquilerController(apphouseContext context)
        {
            _context = context;
        }

        // GET: Alquiler
        public async Task<IActionResult> Index()
        {
            var apphouseContext = _context.Alquiler.Include(a => a.Casa).Include(a => a.Cliente);
            return View(await apphouseContext.ToListAsync());
        }

        // GET: Alquiler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alquiler == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquiler
                .Include(a => a.Casa)
                .Include(a => a.Cliente)
                .FirstOrDefaultAsync(m => m.Alquilerid == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // GET: Alquiler/Create
        public IActionResult Create()
        {
            ViewData["CasaID"] = new SelectList(_context.Casa, "Casaid", "Casaname");
            ViewData["Clienteid"] = new SelectList(_context.Cliente, "Clienteid", "Clienteapellido");
            return View();
        }

        // POST: Alquiler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Alquilerid,FechaAlquiler,Clienteid,CasaID,Clientename,Casaname")] Alquiler alquiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alquiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CasaID"] = new SelectList(_context.Casa, "Casaid", "Casaname", alquiler.CasaID);
            ViewData["Clienteid"] = new SelectList(_context.Cliente, "Clienteid", "Clienteapellido", alquiler.Clienteid);
            return View(alquiler);
        }

        // GET: Alquiler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alquiler == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquiler.FindAsync(id);
            if (alquiler == null)
            {
                return NotFound();
            }
            ViewData["CasaID"] = new SelectList(_context.Casa, "Casaid", "Casaname", alquiler.CasaID);
            ViewData["Clienteid"] = new SelectList(_context.Cliente, "Clienteid", "Clienteapellido", alquiler.Clienteid);
            return View(alquiler);
        }

        // POST: Alquiler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Alquilerid,FechaAlquiler,Clienteid,CasaID,Clientename,Casaname")] Alquiler alquiler)
        {
            if (id != alquiler.Alquilerid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alquiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlquilerExists(alquiler.Alquilerid))
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
            ViewData["CasaID"] = new SelectList(_context.Casa, "Casaid", "Casaname", alquiler.CasaID);
            ViewData["Clienteid"] = new SelectList(_context.Cliente, "Clienteid", "Clienteapellido", alquiler.Clienteid);
            return View(alquiler);
        }

        // GET: Alquiler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alquiler == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquiler
                .Include(a => a.Casa)
                .Include(a => a.Cliente)
                .FirstOrDefaultAsync(m => m.Alquilerid == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // POST: Alquiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alquiler == null)
            {
                return Problem("Entity set 'apphouseContext.Alquiler'  is null.");
            }
            var alquiler = await _context.Alquiler.FindAsync(id);
            if (alquiler != null)
            {
                _context.Alquiler.Remove(alquiler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlquilerExists(int id)
        {
          return (_context.Alquiler?.Any(e => e.Alquilerid == id)).GetValueOrDefault();
        }
    }
}
