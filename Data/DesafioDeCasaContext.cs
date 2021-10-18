using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DesafioDeCasa.Models;

namespace DesafioDeCasa.Data
{
    public class DesafioDeCasaContext : DbContext
    {
        public DesafioDeCasaContext (DbContextOptions<DesafioDeCasaContext> options)
            : base(options)
        {
        }

        public DbSet<DesafioDeCasa.Models.Pessoa> Pessoa { get; set; }
        public DbSet<DesafioDeCasa.Models.Loja> Loja { get; set; }
    }
}
