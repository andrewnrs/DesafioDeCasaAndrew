using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioDeCasa.Data;
using DesafioDeCasa.Models;

namespace DesafioDeCasa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : Controller
    {
        private readonly DesafioDeCasaContext _context;

        public PessoasController([FromServices] DesafioDeCasaContext context)
        {
            _context = context;
        }

        // GET: Pessoas
        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> Index()
        {
            return await _context.Pessoa.ToListAsync();
        }

        // GET: Pessoas/Details/5
        [HttpGet("Details/{id}")]
        public async Task<ActionResult<Pessoa>> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        public async Task<ActionResult<Pessoa>> Create([FromBody] [Bind("id,cpf,senha,email,nome,saldo")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return pessoa;
        }

        // GET: Pessoas/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<ActionResult<Pessoa>> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return pessoa;
        }

        // PUT: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}")]
        public async Task<ActionResult<Pessoa>> Edit(long id, [FromBody] [Bind("id,cpf,senha,email,nome,saldo")] Pessoa pessoa)
        {
            if (id != pessoa.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Pessoa p = (Pessoa) _context.Find(typeof(Pessoa), id);
                    p.nome = pessoa.nome;
                    p.email = pessoa.email;
                    p.senha = pessoa.senha;
                    p.saldo = pessoa.saldo;
                    _context.Update(p);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.id))
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
            return pessoa;
        }

        // GET: Pessoas/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<ActionResult<Pessoa>> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        // POST: Pessoas/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);
            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(long id)
        {
            return _context.Pessoa.Any(e => e.id == id);
        }
    }
}
