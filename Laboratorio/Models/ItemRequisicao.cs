using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class ItemRequisicao
    {
        public int Id { get; set; }
        [Display(Name = "Data Cadastro")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        public virtual Requisicao Requisicao { get; set; }
        public int RequisicaoId { get; set; }
        public int ExameId { get; set; }
        public double Valor { get; set; }
    }
}
