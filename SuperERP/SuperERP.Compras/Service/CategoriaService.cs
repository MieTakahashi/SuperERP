using SuperERP.Models;
using SuperERP.Vendas.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.Compras.Service
{
    public static class CategoriaService
    {
        public static void Cadastrar(CategoriaDTO empresa)
        {
            ServicoGenerico<Categoria, CategoriaDTO>.Cadastrar(empresa);
        }
        public static void Alterar(CategoriaDTO empresa)
        {
            ServicoGenerico<Categoria, CategoriaDTO>.Alterar(empresa);
        }
        public static ICollection<CategoriaDTO> Listar()
        {
            return ServicoGenerico<Categoria, CategoriaDTO>.Listar();
        }
        public static void Deletar(int idCategoria)
        {
            ServicoGenerico<Categoria, CategoriaDTO>.Deletar(idCategoria);
        }
        public static CategoriaDTO BuscaPorId(int idCategoria)
        {
            return ServicoGenerico<Categoria, CategoriaDTO>.BuscaPorId(idCategoria);
        }
    }
}
