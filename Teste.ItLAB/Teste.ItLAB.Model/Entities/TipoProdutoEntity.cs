using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Teste.ItLAB.Model.Entities
{
    [Table("tbTIPO")]
    public class TipoProdutoEntity
    {
        [Key]
        public int ID { get; set; }
        public string NOME { get; set; }
        public string DESCRICAO { get; set; }
    }
}
