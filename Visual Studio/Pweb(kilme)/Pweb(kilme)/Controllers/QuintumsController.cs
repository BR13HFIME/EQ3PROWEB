using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pweb_kilme_.Models.dbModels;
using Pweb_kilme_.Models.DTO;

namespace Pweb_kilme_.Controllers
{
    [Authorize]
    public class QuintumsController : Controller
    {
        private readonly PwebdbContext _context;

        public QuintumsController(PwebdbContext context)
        {
            _context = context;
        }

        // GET: Quintums
        public async Task<IActionResult> Index_Usuario()
        {
            return View(await _context.Quinta.ToListAsync());
        }

        public async Task<IActionResult> Index_Admin()
        {
            return View(await _context.Quinta.ToListAsync());
        }

        // GET: Quintums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quintum = await _context.Quinta
                .FirstOrDefaultAsync(m => m.IdQuinta == id);
            if (quintum == null)
            {
                return NotFound();
            }

            return View(quintum);
        }

        // GET: Quintums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quintums/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdQuinta,Nombre,Direccion,PrecioPorPersona,IdImagen,IdRedes")] QuintumDTO quintumDTO)
        {
            if (ModelState.IsValid)
            {
                var quintum = new Quintum
                {
                    IdQuinta = quintumDTO.IdQuinta,
                    Nombre = quintumDTO.Nombre,
                    Direccion = quintumDTO.Direccion,
                    PrecioPorPersona = quintumDTO.PrecioPorPersona,
                    IdImagen = quintumDTO.IdImagen,
                    IdRedes = quintumDTO.IdRedes
                };

                _context.Add(quintum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quintumDTO);
        }

        // GET: Quintums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quintum = await _context.Quinta.FindAsync(id);
            if (quintum == null)
            {
                return NotFound();
            }

            var quintumsDTO = new QuintumDTO
            {
                IdQuinta = quintum.IdQuinta,
                Nombre = quintum.Nombre,
                Direccion = quintum.Direccion,
                PrecioPorPersona = quintum.PrecioPorPersona,
                IdImagen = quintum.IdImagen,
                IdRedes = quintum.IdRedes
            };

            return View(quintumsDTO);
        }

        // POST: Quintums/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdQuinta,Nombre,Direccion,PrecioPorPersona,IdImagen,IdRedes")] QuintumDTO quintumDTO)
        {
            if (id != quintumDTO.IdQuinta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var quintum = new Quintum
                    {
                        IdQuinta = quintumDTO.IdQuinta,
                        Nombre = quintumDTO.Nombre,
                        Direccion = quintumDTO.Direccion,
                        PrecioPorPersona = quintumDTO.PrecioPorPersona,
                        IdImagen = quintumDTO.IdImagen,
                        IdRedes = quintumDTO.IdRedes
                    };

                    _context.Update(quintum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuintumExists(quintumDTO.IdQuinta))
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
            return View(quintumDTO);
        }

        // GET: Quintums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quintum = await _context.Quinta
                .FirstOrDefaultAsync(m => m.IdQuinta == id);
            if (quintum == null)
            {
                return NotFound();
            }

            return View(quintum);
        }

        // POST: Quintums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quintum = await _context.Quinta.FindAsync(id);
            if (quintum != null)
            {
                _context.Quinta.Remove(quintum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuintumExists(int id)
        {
            return _context.Quinta.Any(e => e.IdQuinta == id);
        }
    }
}
