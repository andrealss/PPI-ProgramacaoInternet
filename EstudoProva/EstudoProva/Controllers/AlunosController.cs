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
    public class AlunosController : Controller
    {
        private readonly EstudoProvaContext _context;

        public AlunosController(EstudoProvaContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            // .Include(c=>c.curso)
            return View(await _context.Aluno.Include(c=>c.curso) .ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .SingleOrDefaultAsync(m => m.ra == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            //Adicionado - ViewBag.ListaCursos = new SelectList (_context.Curso.ToList(), "identificador", "nome");
            ViewBag.ListaCursos = new SelectList(_context.Curso.ToList(),"identificador","nome");
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Adicionado cursoID no public async
        public async Task<IActionResult> Create([Bind("ra,nome,data_nasc,cpf,rg,sexo,cursoID")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno.SingleOrDefaultAsync(m => m.ra == id);
            if (aluno == null)
            {
                return NotFound();
            }
            //Adiconado - ViewBag.ListaCursos = new SelectList(_context.Curso.ToList(),"identificador","nome", aluno.cursoID);
            ViewBag.ListaCursos = new SelectList(_context.Curso.ToList(), "identificador","nome",aluno.cursoID);
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Adicionando cursoID
        public async Task<IActionResult> Edit(string id, [Bind("ra,nome,data_nasc,cpf,rg,sexo,cursoID")] Aluno aluno)
        {
            if (id != aluno.ra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.ra))
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
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .SingleOrDefaultAsync(m => m.ra == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var aluno = await _context.Aluno.SingleOrDefaultAsync(m => m.ra == id);
            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(string id)
        {
            return _context.Aluno.Any(e => e.ra == id);
        }
    }
}
