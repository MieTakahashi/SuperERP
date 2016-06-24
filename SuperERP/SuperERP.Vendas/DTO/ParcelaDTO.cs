using System;

namespace SuperERP.Vendas.DTO
{
    public class ParcelaDTO
    {
        public int ParcelaId { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Valor { get; set; }
        public string Observacao { get; set; }
    }
}
