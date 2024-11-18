using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pweb_kilme_.Models.dbModels;

namespace Pweb_kilme_.Controllers
{
    public class QuintumsController : Controller
    {
        private readonly PwebdbContext _context;

        public QuintumsController(PwebdbContext context)
        {
            _context = context;
        }

        // GET: Quintums
        public async Task<IActionResult> Index()
        {
            var pwebdbContext = _context.Quinta.Include(q => q.IdImagenNavigation).Include(q => q.IdRedesNavigation);
            return View(await pwebdbContext.ToListAsync());
        }

        // GET: Quintums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quintum = await _context.Quinta
                .Include(q => q.IdImagenNavigation)
                .Include(q => q.IdRedesNavigation)
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
            ViewData["IdImagen"] = new SelectList(_context.Imgsquinta, "IdImg", "IdImg");
            ViewData["IdRedes"] = new SelectList(_context.Redessociales, "IdRedes", "IdRedes");
            return View();
        }

        // POST: Quintums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrecioPorPersona,Direccion,IdRedes,IdQuinta,IdImagen,Nombre")] Quintum quintum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quintum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdImagen"] = new SelectList(_context.Imgsquinta, "IdImg", "IdImg", quintum.IdImagen);
            ViewData["IdRedes"] = new SelectList(_context.Redessociales, "IdRedes", "IdRedes", quintum.IdRedes);
            return View(quintum);
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
            ViewData["IdImagen"] = new SelectList(_context.Imgsquinta, "IdImg", "IdImg", quintum.IdImagen);
            ViewData["IdRedes"] = new SelectList(_context.Redessociales, "IdRedes", "IdRedes", quintum.IdRedes);
            return View(quintum);
        }

        // POST: Quintums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrecioPorPersona,Direccion,IdRedes,IdQuinta,IdImagen,Nombre")] Quintum quintum)
        {
            if (id != quintum.IdQuinta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quintum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuintumExists(quintum.IdQuinta))
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
            ViewData["IdImagen"] = new SelectList(_context.Imgsquinta, "IdImg", "IdImg", quintum.IdImagen);
            ViewData["IdRedes"] = new SelectList(_context.Redessociales, "IdRedes", "IdRedes", quintum.IdRedes);
            return View(quintum);
        }

        // GET: Quintums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quintum = await _context.Quinta
                .Include(q => q.IdImagenNavigation)
                .Include(q => q.IdRedesNavigation)
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
