using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SuperERP.Models;


namespace SuperERP.DAL.Repositories
{
    public class OrdemServicoRepositorio : Repositorio<Ordem_Servico>
    {
        public ICollection<Ordem_Servico> listarTudao()
        {
            return dbContext.Ordem_Servico
                .Include(x => x.Servico)
                .Include(x => x.Status_Servico)
                .ToList(); 
        }

        public Ordem_Servico buscarPorID(int ordemID)
        {
            /* var ordem = dbContext.OrdemServico.FirstOrDefault(x=> x.ID == ordemID);
             return ordem;*/
            return dbContext.Ordem_Servico.FirstOrDefault(x => x.ID == ordemID);

        }

        public void salvarOrdemServico(Ordem_Servico ordem)
        {
            if (ordem.ID > 0)
            {
                // update
                var ordemS = dbContext.Ordem_Servico.Find(ordem.ID);

                ordemS.Nome = ordem.Nome;
                ordemS.ID_Servico = ordem.ID_Servico;
                ordemS.ID_Status = ordem.ID_Status;
                ordemS.Numero_Os = ordem.Numero_Os;
                ordemS.DataI_Inicio = ordem.DataI_Inicio;
                ordemS.DataI_Entrega = ordem.DataI_Entrega;
                ordemS.Equipamento_Recebido = ordem.Equipamento_Recebido;
                ordemS.NumeroSerie = ordem.NumeroSerie;
                ordemS.Marca = ordem.Marca;
                ordemS.Modelo = ordem.Modelo;
                ordemS.Obs_Recebimento = ordem.Obs_Recebimento;
                ordemS.Obs_Problema = ordem.Obs_Problema;
                ordemS.Descr_Servico = ordem.Descr_Servico;
                ordemS.Obs_Interno = ordem.Obs_Interno;


            }
            else {

                try
                {
                    dbContext.Ordem_Servico.Add(ordem);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            dbContext.SaveChanges();
        }

        public void deletarOrdemServico(Ordem_Servico ordem)
        {
            dbContext.Ordem_Servico.Remove(ordem);
            dbContext.SaveChanges();
        }
    }
}
