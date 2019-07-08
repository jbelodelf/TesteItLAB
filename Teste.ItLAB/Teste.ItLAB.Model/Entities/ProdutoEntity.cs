using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Teste.ItLAB.Model.Entities
{
    [Table("tbPRODUTO")]
    public class ProdutoEntity
    {
        [Key]
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

        [ForeignKey("IDTIPO")]
        public TipoProdutoEntity TipoProduto { get; set; }

        public bool ValidaProduto()
        {
            bool retorno = false;
            bool NomeValido = this.NOME != "" ? true : false;
            bool TipoValido = this.IDTIPO != 0 ? true : false;
            bool DtFabricacaoValido = this.DTFABRICACAO != null ? true : false;
            bool ValorValido = this.VALOR > 0 ? true : false;

            if (NomeValido && TipoValido && DtFabricacaoValido && !ValorValido)
            {
                retorno = true;
            }
            return retorno;
        }
    }
}
