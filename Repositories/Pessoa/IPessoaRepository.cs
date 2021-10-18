using DesafioDeCasa.Data;
using DesafioDeCasa.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDeCasa.Repositories
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        bool PagarPessoa(Pessoa pagador, double valor, Pessoa recebedor);
        bool PagarLoja(Pessoa pagador, double valor, long idLojaRecebedora);
    }
}
