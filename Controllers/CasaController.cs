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
              return _context.Casa != null ? 
                          View(await _context.Casa.ToListAsync()) :
                          Problem("Entity set 'apphouseContext.Casa'  is null.");
        }


        // GET: Casa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Casa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Casaid,Dueñoname,Domicilio,Casaname,imagencasa,metros,MontoF,eliminada,alquilada,Localidad")] Casa casa, IFormFile imagencasa)
        {
            if (ModelState.IsValid)
            {
                if(imagencasa != null && imagencasa.Length > 0) 
                {
                  byte[]? Imagen = null;
                  using(var fs1 = imagencasa.OpenReadStream()) 
                  using(var ms1 = new MemoryStream()) 
                  {
                    fs1.CopyTo(ms1);
                    Imagen = ms1.ToArray();
                  }
                  casa.imagencasa = Imagen;
                  foreach (var item in _context.Casa)
                  {
                    if (item.alquilada == false)
                    {
                        item.MontoF = casa.MontoF;
                    }
                  }
                  _context.SaveChanges();
                }
                _context.Add(casa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(casa);
        }

        // POST: Casa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Casaid,Dueñoname,Domicilio,Casaname,imagencasa,metros,MontoF,eliminada,alquilada,Localidad")] Casa casa, IFormFile imagencasa)
        {
            if (id != casa.Casaid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     if(imagencasa != null && imagencasa.Length > 0) 
                {
                  byte[]? Imagen = null;
                  using(var fs1 = imagencasa.OpenReadStream()) 
                  using(var ms1 = new MemoryStream()) 
                  {
                    fs1.CopyTo(ms1);
                    Imagen = ms1.ToArray();
                  }
                  
                   foreach (var item in _context.Casa)
                  {
                    if(item.Casaid == id)
                    {
                        item.imagencasa = Imagen;
                    }
                    if (item.alquilada == false)
                    {
                        item.MontoF = casa.MontoF;
                    }
                  }
                  _context.SaveChanges();
                }
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
            return View(casa);
        }

        

        // POST: Casa/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           var casa = await _context.Casa.FindAsync(id);
           if (casa.alquilada == true)
           {
            return RedirectToAction(nameof(Index));
           }
           if (casa.eliminada == true)
           {      
             return RedirectToAction(nameof(Index));      
           }
           if (casa != null)
           {
             var alquilada = (from a in _context.Alquiler where a.Casaid == id select a).Count();
             if(alquilada != 0)
             {
                casa.eliminada = true;
                casa.Casaname = casa.Casaname + " (eliminada)"; 
                _context.Update(casa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
             }
             else {
                _context.Casa.Remove(casa);
                await _context.SaveChangesAsync();
             }
           }
           return RedirectToAction(nameof(Index));
        }

        private bool CasaExists(int id)
        {
          return (_context.Casa?.Any(e => e.Casaid == id)).GetValueOrDefault();
        }
    }
}
