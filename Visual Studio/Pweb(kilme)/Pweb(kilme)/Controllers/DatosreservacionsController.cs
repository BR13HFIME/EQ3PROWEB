using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pweb_kilme_.Models.dbModels;
using Microsoft.AspNetCore.Identity;

namespace Pweb_kilme_.Controllers
{
    public class DatosreservacionsController : Controller
    {
        private readonly PwebdbContext _context;

        public DatosreservacionsController(PwebdbContext context)
        {
            _context = context;
        }

        // GET: Datosreservacions
        public async Task<IActionResult> Index()
        {
            var pwebdbContext = _context.Datosreservacions.Include(d => d.IdEstadoNavigation).Include(d => d.IdQuintaNavigation).Include(d => d.IdUsuarioNavigation);
            return View(await pwebdbContext.ToListAsync());
        }

        // GET: Datosreservacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosreservacion = await _context.Datosreservacions
                .Include(d => d.IdEstadoNavigation)
                .Include(d => d.IdQuintaNavigation)
                .Include(d => d.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdReservacion == id);
            if (datosreservacion == null)
            {
                return NotFound();
            }

            return View(datosreservacion);
        }

        // GET: Datosreservacions/Create
        public IActionResult Create(int idQuinta)
        {
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado");
            ViewData["IdQuinta"] = idQuinta;
            return View();
        }

        // POST: Datosreservacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fecha,NumInvitados,IdEstado")] Datosreservacion datosreservacion, int idQuinta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Obtener el ID del usuario y convertirlo a entero
                    var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                    if (int.TryParse(userIdClaim, out int userId))
                    {
                        datosreservacion.IdUsuario = userId;
                        datosreservacion.IdQuinta = idQuinta;

                        // Agregar la reservación al contexto
                        _context.Add(datosreservacion);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "No se pudo obtener el ID del usuario.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al guardar en la base de datos: {ex.Message}");
                    ViewBag.ErrorMessage = "Hubo un problema al guardar la reservación.";
                }
            }

            // Si el modelo no es válido o hay un error, regresa a la vista
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", datosreservacion.IdEstado);
            ViewData["IdQuinta"] = idQuinta;
            return View(datosreservacion);
        }


        // GET: Datosreservacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosreservacion = await _context.Datosreservacions.FindAsync(id);
            if (datosreservacion == null)
            {
                return NotFound();
            }
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", datosreservacion.IdEstado);
            ViewData["IdQuinta"] = new SelectList(_context.Quinta, "IdQuinta", "IdQuinta", datosreservacion.IdQuinta);
            return View(datosreservacion);
        }

        // POST: Datosreservacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReservacion,Fecha,NumInvitados,IdEstado,IdUsuario,IdQuinta")] Datosreservacion datosreservacion)
        {
            if (id != datosreservacion.IdReservacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datosreservacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatosreservacionExists(datosreservacion.IdReservacion))
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
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", datosreservacion.IdEstado);
            ViewData["IdQuinta"] = new SelectList(_context.Quinta, "IdQuinta", "IdQuinta", datosreservacion.IdQuinta);
            return View(datosreservacion);
        }

        // GET: Datosreservacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosreservacion = await _context.Datosreservacions
                .Include(d => d.IdEstadoNavigation)
                .Include(d => d.IdQuintaNavigation)
                .Include(d => d.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdReservacion == id);
            if (datosreservacion == null)
            {
                return NotFound();
            }

            return View(datosreservacion);
        }

        // POST: Datosreservacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datosreservacion = await _context.Datosreservacions.FindAsync(id);
            if (datosreservacion != null)
            {
                _context.Datosreservacions.Remove(datosreservacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatosreservacionExists(int id)
        {
            return _context.Datosreservacions.Any(e => e.IdReservacion == id);
        }
    }
}
