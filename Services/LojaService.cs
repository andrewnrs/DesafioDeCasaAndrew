using DesafioDeCasa.Data;
using DesafioDeCasa.Models;
using DesafioDeCasa.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDeCasa.Services
{
    public class LojaService : LojaRepository
    {
        private readonly DesafioDeCasaContext _context;

        public LojaService([FromServices] DesafioDeCasaContext context) : base(context)
        {
            _context = context;
        }

        public Loja AdicionarLoja(Loja loja)
        {
            if (LojaNova(loja))
            {
                return Adicionar(loja);
            }

            return null;
        }

        public ActionResult<Loja> Remover(long id)
        {
            if (LojaExiste(id))
            {
                Loja loja = Get(id);

                Remover(loja);
            }

            return null;
        }

        internal ActionResult<Loja> Atualizar(long id, Loja lojaNova)
        {
            if (LojaExiste(id) && !LojaNova(lojaNova))
            {
                return Atualizar(lojaNova);
            }

            return null;
        }
    }
}
