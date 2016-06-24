using System;
using System.ComponentModel.DataAnnotations;

namespace SuperERP.Vendas.DTO
{
    public class OrdemServicoDTO
    {

        public int ID { get; set; }
        public string Nome { get; set; }
        public int ID_Servico { get; set; }
        public int ID_Status { get; set; }
        [Display(Name = "Numero da ordem de servico")]
        public string Numero_Os { get; set; }
        [Display(Name = "Data inicio")]
        // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime DataI_Inicio { get; set; }
        [Display(Name = "Data termino")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime DataI_Entrega { get; set; }
        [Display(Name = "Equipamento recebido")]
        public string Equipamento_Recebido { get; set; }
        [Display(Name = "Numero de serie")]
        public string NumeroSerie { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        [Display(Name = "Observaçoes de recebimento")]
        public string Obs_Recebimento { get; set; }
        [Display(Name = "Observações de problemas")]
        public string Obs_Problema { get; set; }
        [Display(Name = "Descrição do serviço")]
        public string Descr_Servico { get; set; }
        [Display(Name = "Observações internas")]
        public string Obs_Interno { get; set; }
        public string Status { get; set; }
        public string Servico { get; set; }

    }
        
}
