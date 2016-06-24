using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SuperERP.Models;

namespace SuperERP.DAL.Repositories
{
    public class ServicoRepositorio : Repositorio<Servico>
    {

        public ICollection<Empresa> PegarEmpresa()
        {
            return dbContext.Empresas.ToList();
        }

        public ICollection<Servico> pegarServicos() {
            return dbContext.Servicoes.ToList();
        }

    }
}
