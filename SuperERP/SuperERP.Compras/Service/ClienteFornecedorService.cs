using SuperERP.Compras.DTO;
using SuperERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.Compras.Service
{
    public static class ClienteFornecedorService
    {
        public static void Cadastrar(ClienteFornecedorDTO empresa)
        {
            ServicoGenerico<ClienteFornecedor, ClienteFornecedorDTO>.Cadastrar(empresa);
        }
        public static void Alterar(ClienteFornecedorDTO empresa)
        {
            ServicoGenerico<ClienteFornecedor, ClienteFornecedorDTO>.Alterar(empresa);
        }
        public static ICollection<ClienteFornecedorDTO> Listar()
        {
            return ServicoGenerico<ClienteFornecedor, ClienteFornecedorDTO>.Listar();
        }
        public static void Deletar(int idClienteFornecedor)
        {
            ServicoGenerico<ClienteFornecedor, ClienteFornecedorDTO>.Deletar(idClienteFornecedor);
        }
        public static ClienteFornecedorDTO BuscaPorId(int idClienteFornecedor)
        {
            return ServicoGenerico<ClienteFornecedor, ClienteFornecedorDTO>.BuscaPorId(idClienteFornecedor);
        }
    }
}
