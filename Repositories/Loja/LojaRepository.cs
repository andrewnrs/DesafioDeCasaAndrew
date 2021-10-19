using DesafioDeCasa.Data;
using DesafioDeCasa.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDeCasa.Repositories
{
    public class LojaRepository : Repository<Loja>, ILojaRepository
    {
        private readonly DesafioDeCasaContext _context;

        public LojaRepository([FromServices] DesafioDeCasaContext context) : base(context)
        {
            _context = context;
        }

        public bool LojaNova(Loja loja)
        {
            // TODO: desconsiderando o fato de Lojas e pessoas possuírem o mesmo email
            return !_context.Loja.Any(e => e.cnpj.ToLower().Equals(loja.cnpj.ToLower())) && !_context.Loja.Any(e => e.email.ToLower().Equals(loja.email.ToLower()));
        }

        public bool LojaExiste(long id)
        {
            return _context.Loja.Any(e => e.id == id);
        }
    }
}
