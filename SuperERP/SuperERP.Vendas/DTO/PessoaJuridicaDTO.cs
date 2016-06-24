using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.Vendas.DTO
{
    public class PessoaJuridicaDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Nome requerido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CNPJ requerido")]
        [RegularExpression(@"^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}\-[0-9]{2}$", ErrorMessage = "CNPJ inválido")]
        public string CNPJ { get; set; }
        [Required(ErrorMessage = "Nome requerido")]
        public string RazaoSocial { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public string Cargo { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
    }
}
