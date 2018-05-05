using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laboratorio.Data;
using Laboratorio.Models;

namespace Laboratorio.Controllers
{
    [Produces("application/json")]
    [Route("api/ApiExame")]
    public class ApiExameController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApiExameController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiExame
        [HttpGet]
        public IEnumerable<Exame> GetExame()
        {
            return _context.Exame;
        }

        // GET: api/ApiExame/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExame([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exame = await _context.Exame.SingleOrDefaultAsync(m => m.Id == id);

            if (exame == null)
            {
                return NotFound();
            }

            return Ok(exame);
        }

        // PUT: api/ApiExame/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExame([FromRoute] int id, [FromBody] Exame exame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exame.Id)
            {
                return BadRequest();
            }

            _context.Entry(exame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpGet("{idTemp}/{exameid}/{preco}")]
        public async Task<IActionResult> ExameTemporario(Guid idTemp, int exameid, double preco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ItemRequisicaoTemp itemTemp = new ItemRequisicaoTemp
            {
                DataCadastro = DateTime.Now,
                ExameId = exameid,
                IdTemporario = idTemp,
                Valor = preco
            };

            _context.ItemRequisicaoTemp.Add(itemTemp);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/ApiExame
        [HttpPost]
        public async Task<IActionResult> PostExame([FromBody] Exame exame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Exame.Add(exame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExame", new { id = exame.Id }, exame);
        }

        // DELETE: api/ApiExame/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExame([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exame = await _context.Exame.SingleOrDefaultAsync(m => m.Id == id);
            if (exame == null)
            {
                return NotFound();
            }

            _context.Exame.Remove(exame);
            await _context.SaveChangesAsync();

            return Ok(exame);
        }

        private bool ExameExists(int id)
        {
            return _context.Exame.Any(e => e.Id == id);
        }
    }
}