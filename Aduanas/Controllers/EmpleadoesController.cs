﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aduanas.Models;

namespace Aduanas.Controllers
{
    public class EmpleadoesController : Controller
    {
        private readonly AduanasContext _context;

        public EmpleadoesController(AduanasContext context)
        {
            _context = context;
        }

        // GET: Empleadoes
        public async Task<IActionResult> Index()
        {
            var aduanasContext = _context.Empleados.Include(e => e.IdAgenciaNavigation).Include(e => e.IdPersonaNavigation).Include(e => e.IdRolNavigation);
            return View(await aduanasContext.ToListAsync());
        }

        // GET: Empleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdAgenciaNavigation)
                .Include(e => e.IdPersonaNavigation)
                .Include(e => e.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleadoes/Create
        public IActionResult Create()
        {
            ViewData["IdAgencia"] = new SelectList(_context.Agencias, "IdAgencia", "NombreAgencia");
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "Nombres");
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "Descripcion");
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersona,IdAgencia,IdRol,Usuario,Clave,FechaInicio,FechaFin,IdEmpleado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAgencia"] = new SelectList(_context.Agencias, "IdAgencia", "IdAgencia", empleado.IdAgencia);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", empleado.IdPersona);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", empleado.IdRol);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["IdAgencia"] = new SelectList(_context.Agencias, "IdAgencia", "IdAgencia", empleado.IdAgencia);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", empleado.IdPersona);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", empleado.IdRol);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersona,IdAgencia,IdRol,Usuario,Clave,FechaInicio,FechaFin,IdEmpleado")] Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado))
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
            ViewData["IdAgencia"] = new SelectList(_context.Agencias, "IdAgencia", "IdAgencia", empleado.IdAgencia);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", empleado.IdPersona);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", empleado.IdRol);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdAgenciaNavigation)
                .Include(e => e.IdPersonaNavigation)
                .Include(e => e.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empleados == null)
            {
                return Problem("Entity set 'AduanasContext.Empleados'  is null.");
            }
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
          return _context.Empleados.Any(e => e.IdEmpleado == id);
        }
    }
}
