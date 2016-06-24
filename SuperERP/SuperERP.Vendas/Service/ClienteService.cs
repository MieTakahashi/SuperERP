using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperERP.DAL.Repositories;
using SuperERP.Vendas.DTO;
using SuperERP.Models;

namespace SuperERP.Vendas.Service
{
    public class ClienteService
    {
        public static ICollection<PessoaFisicaDTO> ListaPessoasFisicas()
        {
            Config.AutoMapperConfig.Inicializar();
            var repositorio = new PessoaFisicaRepositorio();
            var repositorioContato = new ContatoRepository();
            var pessoaFisica = repositorio.ObterTodos();
            var p = Mapper.Map<ICollection<PessoaFisica>, ICollection<PessoaFisicaDTO>>(pessoaFisica);
            if (pessoaFisica != null)
            {
                for (int i = 0; i < pessoaFisica.Count; i++)
                {
                    var contato = repositorioContato.ObterPorPessoaFisica(p.ElementAt(i).ID);
                    if (contato != null)
                    {
                        p.ElementAt(i).Email = contato.Email;
                        p.ElementAt(i).Fone = contato.Fone;
                    }
                }
            }
            return p;
        }

        public static ICollection<PessoaJuridicaDTO> ListaPessoasJuridicas()
        {
            Config.AutoMapperConfig.Inicializar();
            var repositorio = new PessoaJuridicaRepository();
            var repositorioContato = new ContatoRepository();
            var pessoaJuridica = repositorio.ObterTodos();
            var p = Mapper.Map<ICollection<PessoaJuridica>, ICollection<PessoaJuridicaDTO>>(pessoaJuridica);
            if (pessoaJuridica != null)
            {
                for (int i = 0; i < pessoaJuridica.Count; i++)
                {
                    var contato = repositorioContato.ObterPorPessoaJuridica(p.ElementAt(i).ID);
                    if (contato != null)
                    {
                        p.ElementAt(i).Email = contato.Email;
                        p.ElementAt(i).Fone = contato.Fone;
                    }
                }
            }
            return p;
        }

        public static ICollection<ClienteDTO> ListarClientes()
        {
            var repo = new Repositorio<ClienteFornecedor>();
            var listaClienteFornecedor = repo.ObterLista().Where(x => x.Tipo == 0 || x.Tipo == 2);
            var clientes = new List<ClienteDTO>();
            foreach (var cliente in listaClienteFornecedor)
            {
                if (cliente.PessoaFisica != null)
                {
                    clientes.Add(new ClienteDTO { Id = cliente.ID, Nome = cliente.PessoaFisica.Nome });
                }
                else {
                    clientes.Add(new ClienteDTO { Id = cliente.ID, Nome = cliente.PessoaJuridica.Nome });
                }
            }
            return clientes;
        }

        public static void CadastraPessoaFisica(PessoaFisicaDTO p)
        {
            PessoaFisica pessoa = new PessoaFisica();
            var cont = new Contato();
            var end = new Endereco();
            var repositorio = new PessoaFisicaRepositorio();
            pessoa.Nome = p.Nome;
            pessoa.CPF = p.CPF;
            pessoa.RG = p.RG;
            if (p.Email != null)
            {
                cont.Email = p.Email;
                cont.Nome = p.Nome;
                cont.Fone = p.Fone;
                cont.Cargo = p.Cargo;
                List<Contato> contatos = new List<Contato>();
                contatos.Add(cont);
            }
            if (p.Endereco != null)
            {
                end.Endereco1 = p.Endereco;
                end.Numero = p.Numero;
                end.Complemento = p.Complemento;
                end.CEP = p.CEP;
                end.Bairro = p.Bairro;
                end.Cidade = p.Cidade;
                List<Endereco> endereco = new List<Endereco>();
                endereco.Add(end);
            }
            var empresa = repositorio.ObterEmpresaDefault();
            pessoa.Empresa = empresa;
            repositorio.CadastraPF(pessoa, cont, end);
        }

        public static void CadastraPessoaJuridica(PessoaJuridicaDTO p)
        {
            PessoaJuridica pessoa = new PessoaJuridica();
            var cont = new Contato();
            var end = new Endereco();
            var repositorio = new PessoaJuridicaRepository();
            pessoa.Nome = p.Nome;
            pessoa.CNPJ = p.CNPJ;
            pessoa.RazaoSocial = p.RazaoSocial;
            if (p.Email != null)
            {
                cont.Email = p.Email;
                cont.Nome = p.Nome;
                cont.Fone = p.Fone;
                cont.Cargo = p.Cargo;
            }
            if (p.Endereco != null)
            {
                end.Endereco1 = p.Endereco;
                end.Numero = p.Numero;
                end.Complemento = p.Complemento;
                end.CEP = p.CEP;
                end.Bairro = p.Bairro;
                end.Cidade = p.Cidade;
            }
            var r = repositorio.ObterEmpresaDefault();
            pessoa.Empresa = r;
            repositorio.CadastraPJ(pessoa, cont, end);
        }

        public static ICollection<Empresa> ListaEmpresas()
        {
            return new PessoaFisicaRepositorio().ObterEmpresas();
        }

        public static PessoaFisicaDTO BuscaPF(int id)
        {
            var repo = new PessoaFisicaRepositorio();
            var dto = new PessoaFisicaDTO();
            var cliente = repo.ObterPorEntidadePorId(id);
            dto.Nome = cliente.Nome;
            dto.RG = cliente.RG;
            dto.CPF = cliente.CPF;

            var end = repo.BuscaEndereco(id);
            if (end != null)
            {
                dto.Endereco = end.Endereco1;
                dto.Numero = end.Numero;
                dto.Complemento = end.Complemento;
                dto.Bairro = end.Bairro;
                dto.Cidade = end.Cidade;
                dto.CEP = end.CEP;
            }

            var cont = repo.BuscaContato(id);
            if (cont != null)
            {
                dto.Fone = cont.Fone;
                dto.Email = cont.Email;
                dto.Cargo = cont.Cargo;
            }

            return dto;
        }
        public static PessoaJuridicaDTO BuscaPJ(int id)
        {
            var repo = new PessoaJuridicaRepository();
            var dto = new PessoaJuridicaDTO();
            var cliente = repo.ObterPorEntidadePorId(id);
            dto.Nome = cliente.Nome;
            dto.CNPJ = cliente.CNPJ;
            dto.RazaoSocial = cliente.RazaoSocial;

            var end = repo.BuscaEndereco(id);
            if (end != null)
            {
                dto.Endereco = end.Endereco1;
                dto.Numero = end.Numero;
                dto.Complemento = end.Complemento;
                dto.Bairro = end.Bairro;
                dto.Cidade = end.Cidade;
                dto.CEP = end.CEP;
            }

            var cont = repo.BuscaContato(id);
            if (cont != null)
            {
                dto.Fone = cont.Fone;
                dto.Email = cont.Email;
                dto.Cargo = cont.Cargo;
            }

            return dto;
        }

        public static void EditaPessoaFisica(PessoaFisicaDTO p)
        {
            PessoaFisica pessoa = new PessoaFisica();
            var cont = new Contato();
            var end = new Endereco();
            var repositorio = new PessoaFisicaRepositorio();
            pessoa.ID = p.ID;
            pessoa.Nome = p.Nome;
            pessoa.CPF = p.CPF;
            pessoa.RG = p.RG;
            if (p.Email != null)
            {
                cont.Email = p.Email;
                cont.Nome = p.Nome;
                cont.Fone = p.Fone;
                cont.Cargo = p.Cargo;
                List<Contato> contatos = new List<Contato>();
                contatos.Add(cont);
            }

            if (p.Endereco != null)
            {
                end.Endereco1 = p.Endereco;
                end.Numero = p.Numero;
                end.Complemento = p.Complemento;
                end.CEP = p.CEP;
                end.Bairro = p.Bairro;
                end.Cidade = p.Cidade;
                List<Endereco> endereco = new List<Endereco>();
                endereco.Add(end);
            }
            var empresa = repositorio.ObterEmpresaDefault();
            pessoa.Empresa = empresa;
            repositorio.EditaPF(pessoa, cont, end);
        }

        public static void EditaPessoaJuridica(PessoaJuridicaDTO p)
        {
            PessoaJuridica pessoa = new PessoaJuridica();
            var cont = new Contato();
            var end = new Endereco();
            var repositorio = new PessoaJuridicaRepository();
            pessoa.ID = p.ID;
            pessoa.Nome = p.Nome;
            pessoa.CNPJ = p.CNPJ;
            pessoa.RazaoSocial = p.RazaoSocial;
            if (p.Email != null)
            {
                cont.Email = p.Email;
                cont.Nome = p.Nome;
                cont.Fone = p.Fone;
                cont.Cargo = p.Cargo;
            }
            if (p.Endereco != null)
            {
                end.Endereco1 = p.Endereco;
                end.Numero = p.Numero;
                end.Complemento = p.Complemento;
                end.CEP = p.CEP;
                end.Bairro = p.Bairro;
                end.Cidade = p.Cidade;
            }
            var r = repositorio.ObterEmpresaDefault();
            pessoa.Empresa = r;
            repositorio.EditaPJ(pessoa, cont, end);
        }

        public static void ExcluirCliente(int id, int tipo)
        {
            if (tipo == 1)
            {
                var repositorio = new PessoaFisicaRepositorio();
                var end = repositorio.BuscaEndereco(id);
                var pf = repositorio.ObterPorEntidadePorId(id);
                repositorio.ExcluiContato(pf.ID);
                repositorio.ExcluiEndereco(pf.ID);
                repositorio.Deletar(pf);
            }
            else if (tipo == 2)
            {
                var repositorio = new PessoaJuridicaRepository();
                var cont = repositorio.BuscaContato(id);
                var pj = repositorio.ObterPorEntidadePorId(id);
                repositorio.ExcluiContato(pj.ID);
                repositorio.ExcluiEndereco(pj.ID);
                repositorio.Deletar(pj);
            }
        }
    }
}
