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
    public class ClienteController : Controller
    {
        private readonly apphouseContext _context;

        public ClienteController(apphouseContext context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
              return _context.Cliente != null ? 
                          View(await _context.Cliente.ToListAsync()) :
                          Problem("Entity set 'apphouseContext.Cliente'  is null.");
        }


        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Clienteid,Clientename,Clienteapellido,DNI,Fechanacimiento,Localidad")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Clienteid,Clientename,Clienteapellido,DNI,Fechanacimiento,Localidad")] Cliente cliente)
        {
            if (id != cliente.Clienteid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Clienteid))
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
            return View(cliente);
        }


        // POST: Cliente/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           var cliente = await _context.Cliente.FindAsync(id);
           if (cliente != null)
           {
             var alquilada = (from a in _context.Alquiler where a.Clienteid == id select a).Count();
             if(alquilada != 0)
             {
                
                return RedirectToAction(nameof(Index));
             }
             else {
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
             }
           }
           return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return (_context.Cliente?.Any(e => e.Clienteid == id)).GetValueOrDefault();
        }
    }
}
