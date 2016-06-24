using SuperERP.Models;
using SuperERP.Vendas.DTO;

namespace SuperERP.Vendas.Config
{
    public static class AutoMapperConfig
    {
        public static void Inicializar() {
            ConverteDTOParaModel();
            ConverteModelParaDTO();
        }

        public static void ConverteDTOParaModel()
        {
            AutoMapper.Mapper.CreateMap<PessoaFisicaDTO, PessoaFisica>();
            AutoMapper.Mapper.CreateMap<PessoaJuridicaDTO, PessoaJuridica>();
            AutoMapper.Mapper.CreateMap<ParcelamentoDTO, Parcelamento>();
            AutoMapper.Mapper.CreateMap<ProdutoEstoqueDTO, Produto>();
            AutoMapper.Mapper.CreateMap<VendaDTO, Venda>();
            AutoMapper.Mapper.CreateMap<VendaAtivosDTO, Venda_Ativos>();
            AutoMapper.Mapper.CreateMap<VendaAtivosEstoqueDTO, Venda_Ativos>();
            AutoMapper.Mapper.CreateMap<CompraAtivosEstoqueDTO, Compra_Ativos>();
            AutoMapper.Mapper.CreateMap<CategoriaDTO, Categoria>();
            AutoMapper.Mapper.CreateMap<EmpresaDTO, Empresa>();
            AutoMapper.Mapper.CreateMap<OrdemServicoDTO, Ordem_Servico>().ForSourceMember(x => x.Servico, y => y.Ignore());
            AutoMapper.Mapper.CreateMap<ServicoDTO, Servico>();
            AutoMapper.Mapper.CreateMap<StatusServicoDTO, Status_Servico>();
        }




        public static void ConverteModelParaDTO()
        {
            AutoMapper.Mapper.CreateMap<PessoaFisica, PessoaFisicaDTO>();
            AutoMapper.Mapper.CreateMap<PessoaJuridica, PessoaJuridicaDTO>();
            AutoMapper.Mapper.CreateMap<Parcelamento, ParcelamentoDTO>();
            AutoMapper.Mapper.CreateMap<Produto, ProdutoEstoqueDTO>();
            AutoMapper.Mapper.CreateMap<Venda, VendaDTO>();
            AutoMapper.Mapper.CreateMap<Venda_Ativos, VendaAtivosDTO>();
            AutoMapper.Mapper.CreateMap<Venda_Ativos, VendaAtivosEstoqueDTO>();
            AutoMapper.Mapper.CreateMap<Compra_Ativos, CompraAtivosEstoqueDTO>();
            AutoMapper.Mapper.CreateMap<Categoria, CategoriaDTO>();
            AutoMapper.Mapper.CreateMap<Empresa, EmpresaDTO>();
            AutoMapper.Mapper.CreateMap<Ordem_Servico, OrdemServicoDTO>()
                .ForMember(x => x.Status, y => y.MapFrom(o => o.Status_Servico.Nome))
                .ForMember(x=> x.Servico, y=> y.MapFrom(o=> o.Servico.Nome));
            AutoMapper.Mapper.CreateMap<Servico, ServicoDTO>();
            AutoMapper.Mapper.CreateMap<Status_Servico, StatusServicoDTO>();
        }
    }
}
