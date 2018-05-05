using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class ItemTabelaPreco
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        public virtual Exame Exame { get; set; }
        public int ExameId { get; set; }
        public virtual TabelaPreco TabelaPreco { get; set; }
        public int TabelaPrecoId { get; set; }
        public double Ponto { get; set; }
        public virtual PostoColeta PostoColeta { get; set; }
        public Guid PostoColetaId { get; set; }
    }
}
