using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Teste.ItLAB.Data.Repositories.Base;
using Teste.ItLAB.Model.Entities;
using Teste.ItLAB.Model.Interfaces;

namespace Teste.ItLAB.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ContextAplication _context;
        public ProdutoRepository(ContextAplication context)
        {
            _context = context;
        }

        public bool AddProduto(ProdutoEntity produto)
        {
            using (var rep = new RepositoryBase<ProdutoEntity>(_context))
            {
                rep.Insert(produto);
            }
            return true;
        }

        public bool DeleteProduto(int Id)
        {
            Expression<Func<ProdutoEntity, bool>> expressionFiltro = (a => a.ID == Id);

            using (var rep = new RepositoryBase<ProdutoEntity>(_context))
            {
                var produtoEntity = rep.Select(expressionFiltro).FirstOrDefault();
                if(produtoEntity != null)
                {
                    rep.Delete(produtoEntity);
                }
            }
            return true;
        }

        public ProdutoEntity GetProduto(int Id)
        {
            ProdutoEntity produtoEntity = new ProdutoEntity();
            Expression<Func<ProdutoEntity, bool>> expressionFiltro = (a => a.ID == Id);
            string[] includes = new string[] { "TipoProduto" };

            using (var rep = new RepositoryBase<ProdutoEntity>(_context))
            {
                produtoEntity = rep.Select(expressionFiltro, includes).FirstOrDefault();
            }
            return produtoEntity;
        }

        public ProdutoEntity GetProduto(string Nome)
        {
            ProdutoEntity produtoEntity = new ProdutoEntity();
            Expression<Func<ProdutoEntity, bool>> expressionFiltro = (a => a.NOME.Trim() == Nome.Trim());
            string[] includes = new string[] { "TipoProduto" };

            using (var rep = new RepositoryBase<ProdutoEntity>(_context))
            {
                produtoEntity = rep.Select(expressionFiltro, includes).FirstOrDefault();
            }
            return produtoEntity;
        }

        public List<ProdutoEntity> GetProdutos()
        {
            string[] includes = new string[] { "TipoProduto" };
            List<ProdutoEntity> produtos = new List<ProdutoEntity>();
            using (var rep = new RepositoryBase<ProdutoEntity>(_context))
            {
                produtos = rep.Select(includes).ToList();
            }
            return produtos;
        }

        public bool UpdateProduto(ProdutoEntity produto)
        {
            using (var rep = new RepositoryBase<ProdutoEntity>(_context))
            {
                rep.Update(produto);
            }
            return true;
        }
    }
}
