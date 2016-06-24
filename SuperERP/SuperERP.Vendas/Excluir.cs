using SuperERP.DAL.Repositories;
using SuperERP.Models;
using SuperERP.Vendas.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.Vendas
{
    public class Excluir
    {
        public static void Venda(int id)
        {
            var vendaRep = new Repositorio<Venda>();
            vendaRep.Deletar(id);
        }
    }
}
