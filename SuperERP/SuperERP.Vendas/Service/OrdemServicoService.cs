using System;
using System.Collections.Generic;
using SuperERP.Vendas.DTO;
using SuperERP.DAL.Repositories;
using AutoMapper;
using SuperERP.Models;

namespace SuperERP.Vendas.Service
{
    public class OrdemServicoService
    {
        public void savarOrdemServico(OrdemServicoDTO ordem) {

            // converter o dto em obj model antes de enviar para o repositorio
            //  var ordemServico = new Ordem_Servico();
            //  var ordemServico = Mapper.Map<OrdemServicoDTO , Ordem_Servico>(ordem);

            var ordemS = new Ordem_Servico();

                ordemS.ID = ordem.ID;
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

            var gravar = new OrdemServicoRepositorio();
            gravar.salvarOrdemServico(ordemS);

        }

        public OrdemServicoDTO buscarOrdemServico(int idOrdem) {

            // converter o retorno que é um objeto model para um dto

            var ordem = new OrdemServicoRepositorio().buscarPorID(idOrdem);

            var ordemDTO = Mapper.Map<Ordem_Servico, OrdemServicoDTO> (ordem);

            return ordemDTO;
        }

        public ICollection<OrdemServicoDTO> listOrdemServico() {

            // ira receber uma coleção de objetos

            var listOrdem = new OrdemServicoRepositorio().listarTudao();

            var listaOrdemDTO = Mapper.Map<ICollection<Ordem_Servico> , ICollection<OrdemServicoDTO>>(listOrdem);

            return listaOrdemDTO;
        }

        public ICollection<StatusServicoDTO> listarStatus() {

            var listarStatus = new StatusServicoRepositorio().pegarStatusServico();
            var listStatusDTO = Mapper.Map<ICollection<Status_Servico>, ICollection< StatusServicoDTO>>(listarStatus);
            return listStatusDTO;
        }

        public ICollection<ServicoDTO> listarServicos() {

            var listarServicos = new ServicoRepositorio().pegarServicos();
            var listServicoDTO = Mapper.Map<ICollection<Servico>, ICollection<ServicoDTO>>(listarServicos);
            return listServicoDTO;
        }
    }
}
