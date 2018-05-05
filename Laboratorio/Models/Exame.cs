using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class Exame
    {
        public int Id { get; set; }
        [Display(Name = "Data Cadastro")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        public string Codigo { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string Sinonimo { get; set; }
        public double Preco { get; set; }
    }
}
