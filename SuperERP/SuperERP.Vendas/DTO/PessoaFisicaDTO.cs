using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.Vendas.DTO
{
    public class PessoaFisicaDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Nome requerido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF requerido")]
        [RegularExpression(@"^[0-9]{3}\.[0-9]{3}\.[0-9]{3}\-[0-9]{2}$", ErrorMessage = "CPF inválido")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "RG requerido")]
        [RegularExpression(@"^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\-[0-9]{1}$", ErrorMessage = "RG inválido")]
        public string RG { get; set; }
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        [RegularExpression(@"^\([0-9]{2}\)[ ]{0,1}[0-9]{4,5}\-[0-9]{4}$", ErrorMessage = "Telefone inválido")]
        public string Fone { get; set; }
        public string Cargo { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        [RegularExpression(@"^[\wçÇáéíóúýÁÉÍÓÚÝàèìòùÀÈÌÒÙãõñäëïöüÿÄËÏÖÜÃÕÑâêîôûÂÊÎÔÛ ]{1,}\/[\wçÇáéíóúýÁÉÍÓÚÝàèìòùÀÈÌÒÙãõñäëïöüÿÄËÏÖÜÃÕÑâêîôûÂÊÎÔÛ ]{2}$", ErrorMessage = "Cidade inválida")]
        public string Cidade { get; set; }
        [RegularExpression(@"^[0-9]{5}\-[0-9]{3}$", ErrorMessage = "CEP inválido")]
        public string CEP { get; set; }
    }
}
