using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.Vendas.DTO
{
    public class ServicoDTO
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }
        public int ID_Categoria_Servico { get; set; }
        public string Nome { get; set; }  
        public double ISS { get; set; }
        public double ICMS { get; set; }
        public double IVA { get; set; }
        public double ST { get; set; }
        public double PIS { get; set; }
        public double COFINS { get; set; }
        public Nullable<double> valor { get; set; }
        public Nullable<double> custo { get; set; }
    }
}
