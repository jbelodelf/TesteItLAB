using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.ItLAB.Model.Dtos
{
    public class ProdutoDTO
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public int IDTIPO { get; set; }
        public DateTime DTFABRICACAO { get; set; }
        public decimal VALOR { get; set; }
        public DateTime DATACADASTRO { get; set; }
        public bool DISPONIVEL { get; set; }
        public string NORTE { get; set; }
        public string SUL { get; set; }
        public string LESTE { get; set; }
        public string OESTE { get; set; }

        public TipoProdutoDTO TipoProduto { get; set; }
    }
}
