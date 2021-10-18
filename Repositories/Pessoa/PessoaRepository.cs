using DesafioDeCasa.Data;
using DesafioDeCasa.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDeCasa.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        private readonly DesafioDeCasaContext _context;

        public PessoaRepository([FromServices] DesafioDeCasaContext context) : base (context)
        {
            _context = context;
        }

        public bool PagarPessoa(Pessoa pagador, double valor, Pessoa recebedor)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {

                pagador.saldo -= valor;
                recebedor.saldo += valor;

                _context.Pessoa.Update(pagador);
                _context.Pessoa.Update(recebedor);

                _context.SaveChanges();

                transaction.Commit();

                return true;
            }
            catch (Exception e)
            {
                // TODO: Gerenciar excessões   
            }

            return false;
        }

        public bool PagarLoja(Pessoa pagador, double valor, long idPessoaRecebedora)
        {

            return true;
        }

        public bool PessoaUnica(Pessoa pessoa)
        {
            return !_context.Pessoa.Any(e => e.cpf.ToLower().Equals(pessoa.cpf.ToLower())) && !_context.Pessoa.Any(e => e.email.ToLower().Equals(pessoa.email.ToLower()));
        }

        public bool PessoaExiste(long id)
        {
            return _context.Pessoa.Any(e => e.id == id);
        }
    }
}
