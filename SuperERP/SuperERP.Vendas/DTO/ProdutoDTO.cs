namespace SuperERP.Vendas.DTO
{
    public class ProdutoDTO
    {
        public int ProdutoId { get; set; }
        public string Detalhe { get; set;}
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal Subtotal { get; set; }
    }
}
