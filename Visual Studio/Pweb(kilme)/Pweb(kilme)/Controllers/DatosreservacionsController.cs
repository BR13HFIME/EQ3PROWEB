﻿using System;
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
    [Authorize(Roles = "Admin")]
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
        public IActionResult Create()
        {
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado");
            ViewData["IdQuinta"] = new SelectList(_context.Quinta, "IdQuinta", "IdQuinta");
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Datosreservacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReservacion,Fecha,NumInvitados,IdEstado,IdUsuario,IdQuinta")] DatosreservacionDTO datosreservacionDTO)
        {
            if (ModelState.IsValid)
            {
                var datosreservacion = new Datosreservacion
                {
                    IdEstado = datosreservacionDTO.IdEstado,
                    IdQuinta = datosreservacionDTO.IdQuinta,
                    IdUsuario = datosreservacionDTO.IdUsuario,
                    Fecha = datosreservacionDTO.Fecha,
                    NumInvitados = datosreservacionDTO.NumInvitados
                };
                _context.Add(datosreservacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", datosreservacionDTO.IdEstado);
            ViewData["IdQuinta"] = new SelectList(_context.Quinta, "IdQuinta", "IdQuinta", datosreservacionDTO.IdQuinta);
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", datosreservacionDTO.IdUsuario);
            return View(datosreservacionDTO);
        }

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

            var datosreservacionDTO = new DatosreservacionDTO
            {
                IdReservacion = datosreservacion.IdReservacion,
                Fecha = datosreservacion.Fecha,
                NumInvitados = datosreservacion.NumInvitados,
                IdEstado = datosreservacion.IdEstado,
                IdUsuario = datosreservacion.IdUsuario,
                IdQuinta = datosreservacion.IdQuinta,
                Estados = new SelectList(_context.Estados, "IdEstado", "Estado1", datosreservacion.IdEstado),
                Usuarios = new SelectList(_context.Users, "Id", "UserName", datosreservacion.IdUsuario),
                Quintas = new SelectList(_context.Quinta, "IdQuinta", "Nombre", datosreservacion.IdQuinta)
            };

            return View(datosreservacionDTO);
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
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", datosreservacion.IdUsuario);
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
