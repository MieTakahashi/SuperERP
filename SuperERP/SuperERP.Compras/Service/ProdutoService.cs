using SuperERP.Compras.DTO;
using SuperERP.Vendas.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SuperERP.Models;

namespace SuperERP.Compras.Service
{
    public class ProdutoService
    {
        public static void Cadastrar(SuperERP.Compras.DTO.ProdutoDTO produto)
        {
            ServicoGenerico<Produto, SuperERP.Compras.DTO.ProdutoDTO>.Cadastrar(produto);
        }
        public static void Alterar(SuperERP.Compras.DTO.ProdutoDTO produto)
        {
            ServicoGenerico<Produto, SuperERP.Compras.DTO.ProdutoDTO>.Alterar(produto);
        }
        public static ICollection<SuperERP.Compras.DTO.ProdutoDTO> Listar()
        {
            return ServicoGenerico<Produto, SuperERP.Compras.DTO.ProdutoDTO>.Listar();
        }
        public static void Deletar(int IDProduto)
        {
            ServicoGenerico<Produto, SuperERP.Compras.DTO.ProdutoDTO>.Deletar(IDProduto);
        }

        public static SuperERP.Compras.DTO.ProdutoDTO BuscaPorId(int IdProduto)
        {
            return ServicoGenerico<Produto, SuperERP.Compras.DTO.ProdutoDTO>.BuscaPorId(IdProduto);
        }
    }
}
