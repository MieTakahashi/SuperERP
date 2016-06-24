using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.Compras.DTO
{
    public class ParcelamentoDTO
    {
        public int ID { get; set; }
        public Nullable<int> ID_Compra { get; set; }
        public int Numero_Parcela { get; set; }
        public decimal Valor { get; set; }
        public Nullable<bool> Pago { get; set; }
        public System.DateTime Data_Pagamento { get; set; }
        public Nullable<System.DateTime> Data_Pago { get; set; }
    }
}
