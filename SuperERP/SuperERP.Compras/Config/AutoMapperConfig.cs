using AutoMapper;
using SuperERP.Compras.DTO;
using SuperERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.Compras.Config
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
            Mapper.CreateMap<EmpresaDTO, Empresa>();
            Mapper.CreateMap<PerfilDTO, Perfil>();
            Mapper.CreateMap<ProdutoDTO, Produto>();
            Mapper.CreateMap<FuncionalidadeDTO, Funcionalidade>();
            Mapper.CreateMap<UsuarioDTO, Usuario>();
            Mapper.CreateMap<ClienteFornecedorDTO, ClienteFornecedor>();
            Mapper.CreateMap<CompraAtivosDTO, Compra_Ativos>();
            Mapper.CreateMap<ParcelamentoDTO, Parcelamento>();
        }

        public static void ConverteModelParaDTO()
        {
            Mapper.CreateMap<Empresa, EmpresaDTO>();
            Mapper.CreateMap<Perfil, PerfilDTO >();
            Mapper.CreateMap<Funcionalidade, FuncionalidadeDTO>();
            Mapper.CreateMap<Produto, ProdutoDTO>();
            Mapper.CreateMap<Usuario, UsuarioDTO>();
            Mapper.CreateMap<ClienteFornecedor, ClienteFornecedorDTO>();
            Mapper.CreateMap<Compra_Ativos, CompraAtivosDTO>();
            Mapper.CreateMap<Parcelamento, ParcelamentoDTO>();
        }
    }
}
