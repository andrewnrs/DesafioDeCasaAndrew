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
        public ActionResult<Pessoa> Get([FromRoute] long id)
        {
            return _pessoaService.Get(id);
        }

        // POST: Pessoas/Remover/id
        [HttpPost("Remover/{id}")]
        public ActionResult<Pessoa> Remover([FromRoute] long id)
        {
            return _pessoaService.Remover(id);
        }

        // GET: Pessoas/Atualizar/id
        [HttpPost("Atualizar/{id}")]
        public ActionResult<Pessoa> Atualizar([FromRoute] long id, [Bind("cpf,email,nome,senha,saldo")] [FromBody] Pessoa pessoa)
        {
            return _pessoaService.Atualizar(id, pessoa);
        }

        // POST: Pessoas
        // Bind para proteger de 'Overposting Attacks'
        [HttpPost("")]
        public ActionResult<Pessoa> Post([Bind("cpf,email,nome,senha,saldo")][FromBody] Pessoa pessoa)
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
        public ActionResult<Pessoa> PagarPessoa([FromRoute] long idPagador, [FromRoute] long idRecebedor, [FromRoute] double valor)
        {
            Pessoa pessoa = _pessoaService.PagarPessoa(idPagador, valor, idRecebedor);

            if (pessoa != null)
            {
                return pessoa;
            }

            return BadRequest(ModelState);
            // TODO: Rever retorno caso não
        }

        // PUT: Pagar Pessoas -- Pessoas/1/PagarPessoa/1/10
        [HttpPut("{idPagador}/PagarLoja/{idRecebedor}/{valor}")]
        public ActionResult<Pessoa> PagarLoja([FromRoute] long idPagador, [FromRoute] long idRecebedor, [FromRoute] double valor)
        {
            Pessoa pessoa = _pessoaService.PagarLoja(idPagador, valor, idRecebedor);

            if (pessoa != null)
            {
                return pessoa;
            }

            return BadRequest(ModelState);
            // TODO: Rever retorno caso não
        }
    }
}
