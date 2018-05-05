using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        [Display(Name = "Data Cadastro")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CPF { get; set; }
    }
}
