using AutoMapper;
using SuperERP.DAL.Repositories;
using SuperERP.Models;
using SuperERP.Vendas.DTO;
using System.Collections.Generic;

namespace SuperERP.Vendas
{
    public class Listar
    {
        public static ICollection<PessoaFisicaDTO> PessoasFisicas()
        {
            //ToDo: Ainda deverá ser refatorado
            var pessoaRepo = new PessoaFisicaRepositorio();
            var listaDePessoasFisicas = pessoaRepo.ObterLista();
            var listarDePessoaFisicaDTO = Mapper.Map<ICollection<PessoaFisica>, ICollection<PessoaFisicaDTO>>(listaDePessoasFisicas);
            return new List<PessoaFisicaDTO>();
        }
        public static PessoaFisicaDTO PessoaFisica(int id)
        {
            //ToDo: Ainda deverá ser refatorado
            var pessoaRepo = new PessoaFisicaRepositorio();
            var pessoaFisica = pessoaRepo.ObterPorEntidadePorId(id);
            var pessoaFisicaDTO = Mapper.Map<PessoaFisica, PessoaFisicaDTO>(pessoaFisica);
            return new PessoaFisicaDTO();
        }

        //public static ICollection<CategoriaDTO> CategoriasServico()
        public static ICollection<CategoriaDTO> CategoriasServico()
        {
            Config.AutoMapperConfig.Inicializar();
            var categoriasRep = new DAL.Repositories.CategoriaRepositorio();

            var categorias = categoriasRep.PegarTodasCategorias(true);

            var c = Mapper.Map<ICollection<Categoria>, ICollection<CategoriaDTO>>(categorias);

            return c;
        }

        public static ICollection<EmpresaDTO> Empresas()
        {

            Config.AutoMapperConfig.Inicializar();

            var empresaRep = new ServicoRepositorio();

            var empresa = empresaRep.PegarEmpresa();

            var e = Mapper.Map<ICollection<Empresa>, ICollection<EmpresaDTO>>(empresa);

            return e;

        }

        public static ICollection<ProdutoEstoqueDTO> Estoque()
        {
            Config.AutoMapperConfig.Inicializar();
            var estoqueRep = new EstoqueRepository();
            ICollection<Produto> estoque = estoqueRep.PegarEstoque();
            var estoqueDTO = Mapper.Map<ICollection<Produto>, ICollection<ProdutoEstoqueDTO>>(estoque);
            return estoqueDTO;
        }

        public static ICollection<VendaAtivosEstoqueDTO> VendaAtivosProduto(int idProduto)
        {
            Config.AutoMapperConfig.Inicializar();
            var estoqueRep = new EstoqueRepository();
            ICollection<Venda_Ativos> vendaAtivos = estoqueRep.PegarVendaAtivosDoProduto(idProduto);
            var vendaAtivosDTO = Mapper.Map<ICollection<Venda_Ativos>, ICollection<VendaAtivosEstoqueDTO>>(vendaAtivos);
            return vendaAtivosDTO;
        }

        public static ICollection<CompraAtivosEstoqueDTO> CompraAtivosProduto(int idProduto)
        {
            Config.AutoMapperConfig.Inicializar();
            var estoqueRep = new EstoqueRepository();
            ICollection<Compra_Ativos> compraAtivos = estoqueRep.PegarCompraAtivosDoProduto(idProduto);
            var compraAtivosDTO = Mapper.Map<ICollection<Compra_Ativos>, ICollection<CompraAtivosEstoqueDTO>>(compraAtivos);
            return compraAtivosDTO;
        }

        public static ICollection<PessoaJuridicaDTO> PessoasJuridicas()
        {
            //ToDo: Ainda deverá ser implementado
            return new List<PessoaJuridicaDTO>();
        }

        public static ICollection<ParcelamentoDTO>[] Parcelamentos()
        {
            Config.AutoMapperConfig.Inicializar();
            List<ParcelamentoDTO> parcelasAreceber = new List<ParcelamentoDTO>();
            List<ParcelamentoDTO> parcelasRecebidas = new List<ParcelamentoDTO>();
            List<ParcelamentoDTO> parcelasVencidas = new List<ParcelamentoDTO>();

            ICollection<ParcelamentoDTO>[] parcelas = new ICollection<ParcelamentoDTO>[3];

            var parcelamentoRep = new ParcelasAReceberRepositorio();
            var parcelamentos = parcelamentoRep.PegarTodasParcelas();
            
            var parcelasDTO = Mapper.Map<ICollection<Parcelamento>, ICollection<ParcelamentoDTO>>(parcelamentos);

            foreach (var p in parcelasDTO)
            {
                if (p.Pago == false && System.DateTime.Compare(p.Data_Pagamento, System.DateTime.Today) < 0)
                {
                    parcelasVencidas.Add(p);
                }
                else if (p.Pago == true)
                {
                    parcelasRecebidas.Add(p);
                }
                else if (p.Pago == false && System.DateTime.Compare(p.Data_Pagamento, System.DateTime.Today) > 0)
                {
                    parcelasAreceber.Add(p);
                }
            }
            parcelas[0] = parcelasAreceber;
            parcelas[1] = parcelasRecebidas;
            parcelas[2] = parcelasVencidas;

            return parcelas;
        }
        public static ParcelamentoDTO Parcelamento(int id)
        {
            Config.AutoMapperConfig.Inicializar();
            var parcelamentosRep = new ParcelasAReceberRepositorio();
            var parcela = parcelamentosRep.PegarParcela(id);
            var p = Mapper.Map<Parcelamento, ParcelamentoDTO>(parcela);
            return p;
        }
        public static PessoaJuridicaDTO PessoaJuridica()
        {
            //ToDo: Ainda deverá ser implementado
            return new PessoaJuridicaDTO();
        }
        public static VendaDTO Venda(int id)
        {
            Config.AutoMapperConfig.Inicializar();
            var vendaRep = new VendasRepository();
            var venda = vendaRep.PegarVenda(id);
            var vendaDTO = Mapper.Map<Venda, VendaDTO>(venda);
            return vendaDTO;
        }
        public static ICollection<VendaAtivosDTO> VendaAtivos(int id)
        {
            Config.AutoMapperConfig.Inicializar();
            var vendaAtivosRep = new VendaAtivosRepository();
            var vendaAtivos = vendaAtivosRep.PegarVendaAtivos(id);
            var vendaAtivosDTO = Mapper.Map<ICollection<Venda_Ativos>, ICollection<VendaAtivosDTO>>(vendaAtivos);
            return vendaAtivosDTO;
        }

        public static ICollection<VendaAtivosDTO> VendasOrcamentos()
        {
            Config.AutoMapperConfig.Inicializar();
            var vendaAtivosRep = new VendaAtivosRepository();
            var vendaAtivos = vendaAtivosRep.ObterLista();
            var vendaAtivosDTO = Mapper.Map<ICollection<Venda_Ativos>, ICollection<VendaAtivosDTO>>(vendaAtivos);
            return vendaAtivosDTO;
        }
    }
}
