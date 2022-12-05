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
    public class CasaController : Controller
    {
        private readonly apphouseContext _context;

        public CasaController(apphouseContext context)
        {
            _context = context;
        }

        // GET: Casa
        public async Task<IActionResult> Index()
        {
            var apphouseContext = _context.Casa.Include(c => c.Localidad);
            return View(await apphouseContext.ToListAsync());
        }

        // GET: Casa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Casa == null)
            {
                return NotFound();
            }

            var casa = await _context.Casa
                .Include(c => c.Localidad)
                .FirstOrDefaultAsync(m => m.Casaid == id);
            if (casa == null)
            {
                return NotFound();
            }

            return View(casa);
        }

        // GET: Casa/Create
        public IActionResult Create()
        {
            ViewData["Localidadid"] = new SelectList(_context.Set<Localidad>(), "Localidadid", "Localidadname");
            return View();
        }

        // POST: Casa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Casaid,Dueñoname,Domicilio,Casaname,imagencasa,metros,MontoF,eliminada,alquilada,Localidadid")] Casa casa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Localidadid"] = new SelectList(_context.Set<Localidad>(), "Localidadid", "Localidadname", casa.Localidadid);
            return View(casa);
        }

        // GET: Casa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Casa == null)
            {
                return NotFound();
            }

            var casa = await _context.Casa.FindAsync(id);
            if (casa == null)
            {
                return NotFound();
            }
            ViewData["Localidadid"] = new SelectList(_context.Set<Localidad>(), "Localidadid", "Localidadname", casa.Localidadid);
            return View(casa);
        }

        // POST: Casa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Casaid,Dueñoname,Domicilio,Casaname,imagencasa,metros,MontoF,eliminada,alquilada,Localidadid")] Casa casa)
        {
            if (id != casa.Casaid)
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
                    if (!CasaExists(casa.Casaid))
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
            ViewData["Localidadid"] = new SelectList(_context.Set<Localidad>(), "Localidadid", "Localidadname", casa.Localidadid);
            return View(casa);
        }

        // GET: Casa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Casa == null)
            {
                return NotFound();
            }

            var casa = await _context.Casa
                .Include(c => c.Localidad)
                .FirstOrDefaultAsync(m => m.Casaid == id);
            if (casa == null)
            {
                return NotFound();
            }

            return View(casa);
        }

        // POST: Casa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Casa == null)
            {
                return Problem("Entity set 'apphouseContext.Casa'  is null.");
            }
            var casa = await _context.Casa.FindAsync(id);
            if (casa != null)
            {
                _context.Casa.Remove(casa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasaExists(int id)
        {
          return (_context.Casa?.Any(e => e.Casaid == id)).GetValueOrDefault();
        }
    }
}
