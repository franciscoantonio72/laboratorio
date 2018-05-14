using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class Requisicao
    {
        public int Id { get; set; }
        [Display(Name = "Data Cadastro")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        [Display(Name = "Data Entrega")]
        public DateTime DataEntrega { get; set; }
        public virtual Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
        public virtual Solicitante Solicitante { get; set; }
        public int SolicitanteId { get; set; }
        public virtual Convenio Convenio { get; set; }
        public int ConvenioId { get; set; }
        public virtual PostoColeta PostoColeta { get; set; }
        public Guid PostoColetaId { get; set; }
        public virtual Exame Exame { get; set; }
        public int ExameId { get; set; }
        public double Valor { get; set; }
        public double Desconto { get; set; }
        public double Total { get; set; }
        public Guid IdTemporario { get; set; }

        public virtual ICollection<ItemRequisicao> ItensRequisicao { get; set; }
    }
}
