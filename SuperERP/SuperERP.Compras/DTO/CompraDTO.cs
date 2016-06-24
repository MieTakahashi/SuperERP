using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.Compras.DTO
{
    public class CompraDTO
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }
        public int ID_Fornecedor { get; set; }
        public int ID_Usuario { get; set; }
        public int ID_Status { get; set; }
        public int Compra_Num { get; set; }
        public System.DateTime Data_Compra { get; set; }
        public decimal Desconto { get; set; }
        public int ID_FormaPgto { get; set; }
        public string Observacoes { get; set; }
        public int ID_conta { get; set; }
        public virtual ICollection<CompraAtivosDTO> Compra_Ativos { get; set; }
        public virtual ICollection<ParcelamentoDTO> Parcelamentoes { get; set; }
    }
}
