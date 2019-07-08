using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.ItLAB.Model.Entities;

namespace Teste.ItLAB.Data
{
    public class ContextAplication : DbContext
    {
        public DbSet<ProdutoEntity> Produto { get; set; }
        public DbSet<TipoProdutoEntity> TipoProduto { get; set; }

        public ContextAplication(DbContextOptions<ContextAplication> options)
            : base(options)
        {

        }
    }
}
