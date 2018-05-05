using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class ItemRequisicaoTemp
    {
        public int Id { get; set; }
        public Guid IdTemporario { get; set; }
        public DateTime DataCadastro { get; set; }
        public int ExameId { get; set; }
        public double Valor { get; set; }
    }
}
