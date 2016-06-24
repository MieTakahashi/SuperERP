using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperERP.Models;

namespace SuperERP.DAL.Repositories
{
    public class StatusServicoRepositorio : Repositorio<Status_Servico>
    {
        public ICollection<Status_Servico> pegarStatusServico() {
            return dbContext.Status_Servico.ToList();
        }

    }
}
