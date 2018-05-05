using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Laboratorio.Data;
using Laboratorio.Models;

namespace Laboratorio.Controllers
{
    public class TabelaPrecoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TabelaPrecoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TabelaPrecoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TabelaPreco.Include(t => t.Convenio).Include(t => t.PostoColeta);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TabelaPrecoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaPreco = await _context.TabelaPreco
                .Include(t => t.Convenio)
                .Include(t => t.PostoColeta)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tabelaPreco == null)
            {
                return NotFound();
            }

            return View(tabelaPreco);
        }

        // GET: TabelaPrecoes/Create
        public IActionResult Create()
        {
            ViewData["ConvenioId"] = new SelectList(_context.Convenio, "Id", "Id");
            ViewData["PostoColetaId"] = new SelectList(_context.PostoColeta, "Id", "Id");
            return View();
        }

        // POST: TabelaPrecoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataCadastro,Nome,ConvenioId,PostoColetaId")] TabelaPreco tabelaPreco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabelaPreco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConvenioId"] = new SelectList(_context.Convenio, "Id", "Id", tabelaPreco.ConvenioId);
            ViewData["PostoColetaId"] = new SelectList(_context.PostoColeta, "Id", "Id", tabelaPreco.PostoColetaId);
            return View(tabelaPreco);
        }

        // GET: TabelaPrecoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaPreco = await _context.TabelaPreco.SingleOrDefaultAsync(m => m.Id == id);
            if (tabelaPreco == null)
            {
                return NotFound();
            }
            ViewData["ConvenioId"] = new SelectList(_context.Convenio, "Id", "Id", tabelaPreco.ConvenioId);
            ViewData["PostoColetaId"] = new SelectList(_context.PostoColeta, "Id", "Id", tabelaPreco.PostoColetaId);
            return View(tabelaPreco);
        }

        // POST: TabelaPrecoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataCadastro,Nome,ConvenioId,PostoColetaId")] TabelaPreco tabelaPreco)
        {
            if (id != tabelaPreco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabelaPreco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabelaPrecoExists(tabelaPreco.Id))
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
            ViewData["ConvenioId"] = new SelectList(_context.Convenio, "Id", "Id", tabelaPreco.ConvenioId);
            ViewData["PostoColetaId"] = new SelectList(_context.PostoColeta, "Id", "Id", tabelaPreco.PostoColetaId);
            return View(tabelaPreco);
        }

        // GET: TabelaPrecoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaPreco = await _context.TabelaPreco
                .Include(t => t.Convenio)
                .Include(t => t.PostoColeta)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tabelaPreco == null)
            {
                return NotFound();
            }

            return View(tabelaPreco);
        }

        // POST: TabelaPrecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabelaPreco = await _context.TabelaPreco.SingleOrDefaultAsync(m => m.Id == id);
            _context.TabelaPreco.Remove(tabelaPreco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabelaPrecoExists(int id)
        {
            return _context.TabelaPreco.Any(e => e.Id == id);
        }
    }
}
