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
    public class RequisicoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Guid idTemporario;

        public RequisicoesController(ApplicationDbContext context)
        {
            _context = context;
            idTemporario = Guid.NewGuid();
        }

        // GET: Requisicoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Requisicao.Include(r => r.Convenio).Include(r => r.Exame).Include(r => r.Paciente).Include(r => r.PostoColeta).Include(r => r.Solicitante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Requisicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicao = await _context.Requisicao
                .Include(r => r.Convenio)
                .Include(r => r.Exame)
                .Include(r => r.Paciente)
                .Include(r => r.PostoColeta)
                .Include(r => r.Solicitante)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (requisicao == null)
            {
                return NotFound();
            }

            return View(requisicao);
        }

        // GET: Requisicoes/Create
        public IActionResult Create()
        {
            ViewData["ConvenioId"] = new SelectList(_context.Convenio, "Id", "Nome");
            ViewData["ExameId"] = new SelectList(_context.Exame, "Id", "Codigo");
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id", "Nome");
            ViewData["PostoColetaId"] = new SelectList(_context.PostoColeta, "Id", "Nome");
            ViewData["SolicitanteId"] = new SelectList(_context.Solicitante, "Id", "Nome");
            
            ViewData["IdTemporario"] = idTemporario;

            return View();
        }

        // POST: Requisicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataCadastro,DataEntrega,PacienteId,SolicitanteId,ConvenioId,PostoColetaId,ExameId,Valor,Desconto,Total")] Requisicao requisicao)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<ItemRequisicaoTemp> _exames = _context.ItemRequisicaoTemp.Where(w => w.IdTemporario.Equals(idTemporario)).ToList();
                requisicao.DataCadastro = DateTime.Now;
                _context.Add(requisicao);

                foreach (var item in _exames)
                {
                    ItemRequisicao exame = new ItemRequisicao
                    {
                        DataCadastro = DateTime.Now,
                        ExameId = item.ExameId,
                        RequisicaoId = requisicao.Id,
                        Valor = item.Valor
                    };
                    _context.ItemRequisicao.Add(exame);
                }
               
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConvenioId"] = new SelectList(_context.Convenio, "Id", "Nome", requisicao.ConvenioId);
            ViewData["ExameId"] = new SelectList(_context.Exame, "Id", "Codigo", requisicao.ExameId);
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id", "Nome", requisicao.PacienteId);
            ViewData["PostoColetaId"] = new SelectList(_context.PostoColeta, "Id", "Nome", requisicao.PostoColetaId);
            ViewData["SolicitanteId"] = new SelectList(_context.Solicitante, "Id", "Nome", requisicao.SolicitanteId);
            return View(requisicao);
        }

        // GET: Requisicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicao = await _context.Requisicao.SingleOrDefaultAsync(m => m.Id == id);
            if (requisicao == null)
            {
                return NotFound();
            }
            ViewData["ConvenioId"] = new SelectList(_context.Convenio, "Id", "Id", requisicao.ConvenioId);
            ViewData["ExameId"] = new SelectList(_context.Exame, "Id", "Id", requisicao.ExameId);
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id", "Id", requisicao.PacienteId);
            ViewData["PostoColetaId"] = new SelectList(_context.PostoColeta, "Id", "Id", requisicao.PostoColetaId);
            ViewData["SolicitanteId"] = new SelectList(_context.Solicitante, "Id", "Id", requisicao.SolicitanteId);
            return View(requisicao);
        }

        // POST: Requisicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataCadastro,DataEntrega,PacienteId,SolicitanteId,ConvenioId,PostoColetaId,ExameId,Valor,Desconto,Total")] Requisicao requisicao)
        {
            if (id != requisicao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisicaoExists(requisicao.Id))
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
            ViewData["ConvenioId"] = new SelectList(_context.Convenio, "Id", "Id", requisicao.ConvenioId);
            ViewData["ExameId"] = new SelectList(_context.Exame, "Id", "Id", requisicao.ExameId);
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "Id", "Id", requisicao.PacienteId);
            ViewData["PostoColetaId"] = new SelectList(_context.PostoColeta, "Id", "Id", requisicao.PostoColetaId);
            ViewData["SolicitanteId"] = new SelectList(_context.Solicitante, "Id", "Id", requisicao.SolicitanteId);
            return View(requisicao);
        }

        // GET: Requisicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicao = await _context.Requisicao
                .Include(r => r.Convenio)
                .Include(r => r.Exame)
                .Include(r => r.Paciente)
                .Include(r => r.PostoColeta)
                .Include(r => r.Solicitante)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (requisicao == null)
            {
                return NotFound();
            }

            return View(requisicao);
        }

        // POST: Requisicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requisicao = await _context.Requisicao.SingleOrDefaultAsync(m => m.Id == id);
            _context.Requisicao.Remove(requisicao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisicaoExists(int id)
        {
            return _context.Requisicao.Any(e => e.Id == id);
        }
    }
}
