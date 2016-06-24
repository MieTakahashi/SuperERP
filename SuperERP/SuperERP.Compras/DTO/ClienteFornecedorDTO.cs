using SuperERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.Compras.DTO
{
    public class ClienteFornecedorDTO
    {
        public int ID { get; set; }
        public Nullable<int> ID_PJ { get; set; }
        public Nullable<int> ID_PF { get; set; }
        public int Tipo { get; set; }
        public virtual PessoaFisica PessoaFisica { get; set; }
        public virtual PessoaJuridica PessoaJuridica { get; set; }
    }
}
