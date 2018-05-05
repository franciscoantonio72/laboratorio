using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class TabelaPreco
    {
        public int Id { get; set; }
        [Display(Name = "Data Cadastro")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public virtual Convenio Convenio { get; set; }
        public int ConvenioId { get; set; }
        public virtual ICollection<ItemTabelaPreco> ItensTabelaPreco { get; set; }
        public virtual PostoColeta PostoColeta { get; set; }
        public Guid PostoColetaId { get; set; }
    }
}
