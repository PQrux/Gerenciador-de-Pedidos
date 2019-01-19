using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDePedidos.Models
{
    public class GerenciadorDePedidosContext : DbContext
    {
        public GerenciadorDePedidosContext (DbContextOptions<GerenciadorDePedidosContext> options)
            : base(options)
        {
        }

        public DbSet<GerenciadorDePedidos.Models.Cadastro> Cadastro { get; set; }
    }
}
