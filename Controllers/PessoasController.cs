using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioDeCasa.Data;
using DesafioDeCasa.Models;
using DesafioDeCasa.Services;

namespace DesafioDeCasa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : Controller
    {

        protected PessoaService _pessoaService;

        public PessoasController([FromServices] PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // GET: Pessoas
        [HttpGet("")]
        public IEnumerable<Pessoa> GetAll()
        {
            return _pessoaService.GetAll();
        }

        // GET: Pessoas/id 
        //[HttpPost("")]
        //public ActionResult<Pessoa> Adicionar([Bind("cpf,email,nome,senha,saldo")] [FromBody] Pessoa pessoa)
        //{
        //    return _pessoaService.Adicionar(pessoa);
        //    //return _pessoaService.Get(id);
        //}

        // GET: Pessoas/id 
        [HttpGet("{id}")]
        public ActionResult<Pessoa> Get(long id)
        {
            return _pessoaService.Get(id);
        }

        // POST: Pessoas/Remover/id
        [HttpPost("Remover/{id}")]
        public ActionResult<Pessoa> Remover(long id)
        {
            return _pessoaService.Remover(id);
        }

        // GET: Pessoas/Atualizar/id
        [HttpPost("Atualizar/{id}")]
        public ActionResult<Pessoa> Atualizar(long id, [Bind("cpf,email,nome,senha,saldo")] [FromBody] Pessoa pessoa)
        {
            return _pessoaService.Atualizar(id, pessoa);
        }

        // POST: Pessoas
        // Bind para proteger de 'Overposting Attacks'
        [HttpPost("")]
        public ActionResult<Pessoa> Post([FromServices] DesafioDeCasaContext context, [Bind("cpf,email,nome,senha,saldo")][FromBody] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                
                Pessoa pessoaCadastrada = _pessoaService.AdicionarPessoa(pessoa);

                if (pessoaCadastrada != null)
                {
                    return pessoaCadastrada;
                }
                else
                {
                    return BadRequest(ModelState);
                }

                // TODO: Rever retorno caso não 
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        // PUT: Pagar Pessoas -- Pessoas/1/PagarPessoa/1/10
        [HttpPut("{idPagador}/PagarPessoa/{idRecebedor}/{valor}")]
        public ActionResult<Pessoa> PagarPessoa(long idPagador, long idRecebedor, double valor)
        {
            Pessoa pessoa = _pessoaService.PagarPessoa(idPagador, valor, idRecebedor);

            if (pessoa != null)
            {
                return pessoa;
            }

            return BadRequest(ModelState);
            // TODO: Rever retorno caso não
        }


        // Código antigo, gerado automaticamente pelo VisualStudio durante a adição de um controlador
        // Ajustado manualmente para funcionar corretamente
        //// GET: Pessoas
        //[HttpGet]
        //public async Task<ActionResult<List<Pessoa>>> Index()
        //{
        //    return await _context.Pessoa.ToListAsync();
        //}

        // GET: Pessoas/Details/5
        //[HttpGet("Details/{id}")]
        //public async Task<ActionResult<Pessoa>> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pessoa = await _context.Pessoa
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (pessoa == null)
        //    {
        //        return NotFound();
        //    }

        //    return pessoa;
        //}

        //// GET: Pessoas/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Pessoas/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost("Create")]
        //public async Task<ActionResult<Pessoa>> Create([FromBody] [Bind("id,cpf,senha,email,nome,saldo")] Pessoa pessoa)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(pessoa);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return pessoa;
        //}

        //// GET: Pessoas/Edit/5
        //[HttpGet("Edit/{id}")]
        //public async Task<ActionResult<Pessoa>> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pessoa = await _context.Pessoa.FindAsync(id);
        //    if (pessoa == null)
        //    {
        //        return NotFound();
        //    }
        //    return pessoa;
        //}

        //// PUT: Pessoas/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost("Edit/{id}")]
        //public async Task<ActionResult<Pessoa>> Edit(long id, [FromBody] [Bind("id,cpf,senha,email,nome,saldo")] Pessoa pessoa)
        //{
        //    if (id != pessoa.id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            Pessoa p = (Pessoa) _context.Find(typeof(Pessoa), id);
        //            p.nome = pessoa.nome;
        //            p.email = pessoa.email;
        //            p.senha = pessoa.senha;
        //            p.saldo = pessoa.saldo;
        //            _context.Update(p);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PessoaExists(pessoa.id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return pessoa;
        //}

        //// GET: Pessoas/Delete/5
        //[HttpGet("Delete/{id}")]
        //public async Task<ActionResult<Pessoa>> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pessoa = await _context.Pessoa
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (pessoa == null)
        //    {
        //        return NotFound();
        //    }

        //    return pessoa;
        //}

        //// POST: Pessoas/Delete/5
        //[HttpPost("Delete/{id}"), ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var pessoa = await _context.Pessoa.FindAsync(id);
        //    _context.Pessoa.Remove(pessoa);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PessoaExists(long id)
        //{
        //    return _context.Pessoa.Any(e => e.id == id);
        //}
    }
}
