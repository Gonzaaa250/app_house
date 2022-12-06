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

        // GET: Alquiler/Create
        public IActionResult Create()
        {
            ViewData["Casaid"] = new SelectList(_context.Casa.Where(x => x.alquilada == false && x.eliminada == false), "Casaid", "Casaname");
            ViewData["Clienteid"] = new SelectList(_context.Cliente, "Clienteid", "Clienteapellido");
            return View();
        }

        // POST: Alquiler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Alquilerid,FechaAlquiler,Clienteid,Casaid,MontoTotal,imagencasa,Clientename,Casaname")] Alquiler alquiler)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Cliente = (from a in _context.Cliente where a.Clienteid == alquiler.Clienteid select a).FirstOrDefault();
                    var Casa = (from a in _context.Casa where a.Casaid == alquiler.Casaid select a).FirstOrDefault();
                    if (Casa.Localidad == Cliente.Localidad)
                    {
                        if (Casa.eliminada == false)
                        {
                            alquiler.Casaname = Casa.Casaname;
                            alquiler.Clientename = Cliente.Clientename + " " + Cliente.Clienteapellido;
                            alquiler.MontoTotal = Casa.metros * Casa.MontoF;
                            alquiler.imagencasa = Casa.imagencasa;
                            Casa.alquilada = true;
                            _context.Add(alquiler);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));

                        }

                    }
                }
                catch (System.Exception)
                {

                    throw;
                }


            }
            ViewData["Casaid"] = new SelectList(_context.Casa.Where(x => x.alquilada == false && x.eliminada == false), "Casaid", "Casaname", alquiler.Casaid);
            ViewData["Clienteid"] = new SelectList(_context.Cliente, "Clienteid", "Clienteapellido", alquiler.Clienteid);
            return View(alquiler);
        }
      

        private bool AlquilerExists(int id)
        {
            return (_context.Alquiler?.Any(e => e.Alquilerid == id)).GetValueOrDefault();
        }
    }
}
