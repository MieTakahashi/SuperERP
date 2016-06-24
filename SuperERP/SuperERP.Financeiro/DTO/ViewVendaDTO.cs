using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.Financeiro.DTO
{
    class ViewVendaDTO
    {
        public int ID_PARC { get; set; }
        public int Numero_Parcela { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data_Pagamento { get; set; }
        public DateTime Data_pago { get; set; }
        public int ID_Venda { get; set; }
        public int ID_Empresa { get; set; }
        public int ID_Usuario { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Orcamento { get; set; }
        public int ID_Status { get; set; }
        public int ID_Formapgto { get; set; }
        public int Venda_Num { get; set; }
        public DateTime Data_Venda { get; set; }
        public bool Contrato { get; set; }
        public decimal Desconto { get; set; }
        public string Observacoes { get; set; }
    }
}
