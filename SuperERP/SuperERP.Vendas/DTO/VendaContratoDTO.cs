using System;
using System.Collections.Generic;

namespace SuperERP.Vendas.DTO
{
    public class VendaContratoDTO
    {
        public VendaContratoDTO()
        {
            Parcelas = new List<ParcelaDTO>();
            Produtos = new List<ProdutoDTO>();    
        }
        public int ClienteId { get; set; }
        public DateTime DataVenda { get; set;}
        public int Status { get; set;}
        public bool Contrato { get; set;}
        public decimal Desconto { get; set;}
        public int CondicaoPagamento { get; set; }
        public string FormaDePagamento { get; set;}
        public string Observacao { get; set; }
        public int VendedorId { get; set; }

        public ICollection<ParcelaDTO> Parcelas {get; set;}
        public ICollection<ProdutoDTO> Produtos { get; set; }
    }
}
