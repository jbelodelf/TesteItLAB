using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.ItLAB.Data.Repositories.Base;
using Teste.ItLAB.Model.Entities;
using Teste.ItLAB.Model.Interfaces;
using Teste.ItLAB.Model.Interfaces.Base;

namespace Teste.ItLAB.Data.Repositories
{
    public class TipoProdutoRepository : ITipoProdutoRepository
    {
        private readonly ContextAplication _context;
        public TipoProdutoRepository(ContextAplication context)
        {
            _context = context;
        }

        public List<TipoProdutoEntity> GetTiposProdutos()
        {
            List<TipoProdutoEntity> tiposProdutos = new List<TipoProdutoEntity>();
            using (var rep = new RepositoryBase<TipoProdutoEntity>(_context))
            {
                tiposProdutos = rep.Select().ToList();
            }
            return tiposProdutos;
        }
    }
}
