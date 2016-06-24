using AutoMapper;
using SuperERP.Financeiro.DTO;
using SuperERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.Financeiro.Config
{
    public static class AutoMapperConfig
    {
        public static void Inicializar()
        {
            ConverteDTOParaModel();
            ConverteModelParaDTO();
        }

        public static void ConverteDTOParaModel()
        {
            Mapper.CreateMap<ViewCompraDTO, ViewCompra>();
            Mapper.CreateMap<ViewVendaDTO, ViewVenda>();


        }

        public static void ConverteModelParaDTO()
        {
            Mapper.CreateMap<ViewVenda, ViewVendaDTO>();
            Mapper.CreateMap<ViewCompra, ViewCompraDTO>();
        }
    }
}
