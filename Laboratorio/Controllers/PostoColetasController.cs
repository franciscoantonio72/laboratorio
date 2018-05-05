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
    public class PostoColetasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostoColetasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostoColetas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostoColeta.ToListAsync());
        }

        // GET: PostoColetas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postoColeta = await _context.PostoColeta
                .SingleOrDefaultAsync(m => m.Id == id);
            if (postoColeta == null)
            {
                return NotFound();
            }

            return View(postoColeta);
        }

        // GET: PostoColetas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostoColetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] PostoColeta postoColeta)
        {
            if (ModelState.IsValid)
            {
                postoColeta.Id = Guid.NewGuid();
                _context.Add(postoColeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postoColeta);
        }

        // GET: PostoColetas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postoColeta = await _context.PostoColeta.SingleOrDefaultAsync(m => m.Id == id);
            if (postoColeta == null)
            {
                return NotFound();
            }
            return View(postoColeta);
        }

        // POST: PostoColetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome")] PostoColeta postoColeta)
        {
            if (id != postoColeta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postoColeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostoColetaExists(postoColeta.Id))
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
            return View(postoColeta);
        }

        // GET: PostoColetas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postoColeta = await _context.PostoColeta
                .SingleOrDefaultAsync(m => m.Id == id);
            if (postoColeta == null)
            {
                return NotFound();
            }

            return View(postoColeta);
        }

        // POST: PostoColetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var postoColeta = await _context.PostoColeta.SingleOrDefaultAsync(m => m.Id == id);
            _context.PostoColeta.Remove(postoColeta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostoColetaExists(Guid id)
        {
            return _context.PostoColeta.Any(e => e.Id == id);
        }
    }
}
