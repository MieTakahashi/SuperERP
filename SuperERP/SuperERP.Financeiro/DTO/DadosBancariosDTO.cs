using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.Financeiro.DTO
{
    class DadosBancariosDTO
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }
        public string Banco { get; set; }
        public int Conta_Correne{ get; set; }
        public int Agencia { get; set; }
    }
}
