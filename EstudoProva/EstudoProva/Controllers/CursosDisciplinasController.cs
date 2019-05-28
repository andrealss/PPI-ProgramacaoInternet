using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstudoProva.Models;

namespace EstudoProva.Controllers
{
    public class CursosDisciplinasController : Controller
    {
        private readonly EstudoProvaContext _context;

        public CursosDisciplinasController(EstudoProvaContext context)
        {
            _context = context;
        }

        // GET: CursosDisciplinas
        public async Task<IActionResult> Index()
        {
            var estudoProvaContext = _context.CursoDisciplina
                .Include(c => c.curso)
                .Include(c => c.disciplina);
            return View(await estudoProvaContext.ToListAsync());
        }

        // GET: CursosDisciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.CursoDisciplina
                .Include(c => c.curso)
                .Include(c => c.disciplina)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            return View(cursoDisciplina);
        }

        // GET: CursosDisciplinas/Create
        public IActionResult Create()
        {
            ViewData["cursoID"] = new SelectList(_context.Curso, "identificador", "nome");
            ViewData["disciplinaID"] = new SelectList(_context.Disciplina, "identificador", "nome");
            return View();
        }

        // POST: CursosDisciplinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,cursoID,disciplinaID")] CursoDisciplina cursoDisciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoDisciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cursoID"] = new SelectList(_context.Curso, "identificador", "nome", cursoDisciplina.cursoID);
            ViewData["disciplinaID"] = new SelectList(_context.Disciplina, "identificador", "nome", cursoDisciplina.disciplinaID);
            return View(cursoDisciplina);
        }

        // GET: CursosDisciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.CursoDisciplina.SingleOrDefaultAsync(m => m.ID == id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }
            ViewData["cursoID"] = new SelectList(_context.Curso, "identificador", "nome", cursoDisciplina.cursoID);
            ViewData["disciplinaID"] = new SelectList(_context.Disciplina, "identificador", "nome", cursoDisciplina.disciplinaID);
            return View(cursoDisciplina);
        }

        // POST: CursosDisciplinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,cursoID,disciplinaID")] CursoDisciplina cursoDisciplina)
        {
            if (id != cursoDisciplina.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoDisciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoDisciplinaExists(cursoDisciplina.ID))
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
            ViewData["cursoID"] = new SelectList(_context.Curso, "identificador", "nome", cursoDisciplina.cursoID);
            ViewData["disciplinaID"] = new SelectList(_context.Disciplina, "identificador", "nome", cursoDisciplina.disciplinaID);
            return View(cursoDisciplina);
        }

        // GET: CursosDisciplinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.CursoDisciplina
                .Include(c => c.curso)
                .Include(c => c.disciplina)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            return View(cursoDisciplina);
        }

        // POST: CursosDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursoDisciplina = await _context.CursoDisciplina.SingleOrDefaultAsync(m => m.ID == id);
            _context.CursoDisciplina.Remove(cursoDisciplina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoDisciplinaExists(int id)
        {
            return _context.CursoDisciplina.Any(e => e.ID == id);
        }
    }
}
