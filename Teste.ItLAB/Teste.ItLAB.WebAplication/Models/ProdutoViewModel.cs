using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.ItLAB.WebAplication.Models
{
    public class ProdutoViewModel
    {
        [DisplayName("Id do produto")]
        public int ID { get; set; }
        [DisplayName("Nomo do produto")]
        public string NOME { get; set; }
        [DisplayName("Tipo")]
        public int IDTIPO { get; set; }
        [DisplayName("Data de fabricação")]
        public DateTime DTFABRICACAO { get; set; }
        [DisplayName("Valor")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public decimal VALOR { get; set; }
        [DisplayName("Data do cadastro")]
        public DateTime DATACADASTRO { get; set; }
        public bool DISPONIVEL { get; set; }
        public string NORTE { get; set; }
        public string SUL { get; set; }
        public string LESTE { get; set; }
        public string OESTE { get; set; }

        public TipoProdutoViewModel TipoProduto { get; set; }
    }
}
