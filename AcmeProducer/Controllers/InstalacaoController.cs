using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcmeProducer.Model;

namespace AcmeProducer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstalacaoController : ControllerBase
    {
        private readonly AdventureContext _context;

        public InstalacaoController(AdventureContext context)
        {
            _context = context;
        }

        // GET: api/Instalacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instalacao>>> GetInstalacao()
        {
            return await _context.Instalacao.ToListAsync();
        }

        // GET: api/Instalacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instalacao>> GetInstalacao(int id)
        {
            var instalacao = await _context.Instalacao.FindAsync(id);

            if (instalacao == null)
            {
                return NotFound();
            }

            return instalacao;
        }

        // PUT: api/Instalacao/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstalacao(int id, Instalacao instalacao)
        {
            if (id != instalacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(instalacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstalacaoExists(id))
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

        // POST: api/Instalacao
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Instalacao>> PostInstalacao(Instalacao instalacao)
        {
            _context.Instalacao.Add(instalacao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InstalacaoExists(instalacao.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInstalacao", new { id = instalacao.Id }, instalacao);
        }

        // DELETE: api/Instalacao/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Instalacao>> DeleteInstalacao(int id)
        {
            var instalacao = await _context.Instalacao.FindAsync(id);
            if (instalacao == null)
            {
                return NotFound();
            }

            _context.Instalacao.Remove(instalacao);
            await _context.SaveChangesAsync();

            return instalacao;
        }

        private bool InstalacaoExists(int id)
        {
            return _context.Instalacao.Any(e => e.Id == id);
        }
    }
}
