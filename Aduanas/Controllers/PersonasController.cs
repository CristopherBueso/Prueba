using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aduanas.Models;
using Aduanas.Permisos;
using CustomUserLogin.Utilities;

namespace Aduanas.Controllers
{
    [Authentication]
    [PermisosRolAtribute(Models.Rol.Auxiliar)]
    public class PersonasController : Controller
    {
        private readonly AduanasContext _context;

        public PersonasController(AduanasContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var aduanasContext = _context.Personas.Include(p => p.IdPaisNaturalizacionNavigation).Include(p => p.IdPaisOrigenNavigation).Include(p => p.IdSexoNavigation);
            return View(await aduanasContext.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Personas == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.IdPaisNaturalizacionNavigation)
                .Include(p => p.IdPaisOrigenNavigation)
                .Include(p => p.IdSexoNavigation)
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["IdPaisNaturalizacion"] = new SelectList(_context.Paises, "Id", "Nombre");
            ViewData["IdPaisOrigen"] = new SelectList(_context.Paises, "Id", "Nombre");
            ViewData["IdSexo"] = new SelectList(_context.Sexos, "Id", "Nombre");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersona,Identidad,Nombres,Apellidos,Telefono,Correo,IdPaisOrigen,IdPaisNaturalizacion,IdSexo")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPaisNaturalizacion"] = new SelectList(_context.Paises, "Id", "Id", persona.IdPaisNaturalizacion);
            ViewData["IdPaisOrigen"] = new SelectList(_context.Paises, "Id", "Id", persona.IdPaisOrigen);
            ViewData["IdSexo"] = new SelectList(_context.Sexos, "Id", "Id", persona.IdSexo);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Personas == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["IdPaisNaturalizacion"] = new SelectList(_context.Paises, "Id", "Id", persona.IdPaisNaturalizacion);
            ViewData["IdPaisOrigen"] = new SelectList(_context.Paises, "Id", "Id", persona.IdPaisOrigen);
            ViewData["IdSexo"] = new SelectList(_context.Sexos, "Id", "Id", persona.IdSexo);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersona,Identidad,Nombres,Apellidos,Telefono,Correo,IdPaisOrigen,IdPaisNaturalizacion,IdSexo")] Persona persona)
        {
            if (id != persona.IdPersona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.IdPersona))
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
            ViewData["IdPaisNaturalizacion"] = new SelectList(_context.Paises, "Id", "Id", persona.IdPaisNaturalizacion);
            ViewData["IdPaisOrigen"] = new SelectList(_context.Paises, "Id", "Id", persona.IdPaisOrigen);
            ViewData["IdSexo"] = new SelectList(_context.Sexos, "Id", "Id", persona.IdSexo);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Personas == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.IdPaisNaturalizacionNavigation)
                .Include(p => p.IdPaisOrigenNavigation)
                .Include(p => p.IdSexoNavigation)
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Personas == null)
            {
                return Problem("Entity set 'AduanasContext.Personas'  is null.");
            }
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
          return _context.Personas.Any(e => e.IdPersona == id);
        }
    }
}
