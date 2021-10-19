using DesafioDeCasa.Data;
using DesafioDeCasa.Models;
using DesafioDeCasa.Repositories;
using DesafioDeCasa.EmailHandler;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDeCasa.Services
{
    public class PessoaService : PessoaRepository
    {

        private readonly DesafioDeCasaContext _context;
        private readonly LojaService _lojaService;
        private GerenciadorDeEmail _gerenciadorDeEmail;

        public PessoaService([FromServices] DesafioDeCasaContext context, [FromServices] LojaService lojaService) : base(context)
        {
            _context = context;
            _lojaService = lojaService;
            _gerenciadorDeEmail = new GerenciadorDeEmail();
        }

        public Pessoa AdicionarPessoa(Pessoa pessoa)
        {
            if (PessoaNova(pessoa))
            {
                return Adicionar(pessoa);
            }

            return null;
        }

        public ActionResult<Pessoa> Remover(long id)
        {
            if (PessoaExiste(id))
            {
                Pessoa pessoa = Get(id);

                Remover(pessoa);
            }

            return null;
        }

        public Pessoa PagarPessoa(long idPagador, double valor, long idRecebedor)
        {
            if(PessoaExiste(idPagador) && PessoaExiste(idRecebedor))
            {
                Pessoa pagador = Get(idPagador);
                Pessoa recebedor = Get(idRecebedor);

                if (PagadorPossuiSaldo(pagador, valor) && !pagador.Equals(recebedor))
                {
                    if (PagarPessoa(pagador, valor, recebedor))
                    {
                        _gerenciadorDeEmail.EnviarEmails(pagador.email, recebedor.email, valor, pagador.nome, recebedor.nome);
                        return Get(idPagador);
                    }
                }
            }
            return null;
        }

        public Pessoa PagarLoja(long idPagador, double valor, long idRecebedor)
        {
            if (PessoaExiste(idPagador) && _lojaService.LojaExiste(idRecebedor))
            {
                Pessoa pagador = Get(idPagador);

                Loja recebedor = _lojaService.Get(idRecebedor);

                if (PagadorPossuiSaldo(pagador, valor) && !pagador.Equals(recebedor))
                {
                    if (PagarLoja(pagador, valor, recebedor))
                    {
                        _gerenciadorDeEmail.EnviarEmails(pagador.email, recebedor.email, valor, pagador.nome, recebedor.nome);
                        return Get(idPagador);
                    }
                }
            }
            return null;
        }

        internal ActionResult<Pessoa> Atualizar(long id, Pessoa pessoaNova)
        {
            if (PessoaExiste(id) && !PessoaNova(pessoaNova))
            {
                return Atualizar(pessoaNova);
            }

            return null;
        }

        private bool PagadorPossuiSaldo(Pessoa pessoa, double valor)
        {
            return pessoa.saldo >= valor;
        }

    }
}
