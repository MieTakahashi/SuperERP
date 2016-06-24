using SuperERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.DAL.Repositories
{
    public class PessoaJuridicaRepository : Repositorio<PessoaJuridica>
    {
        public PessoaJuridica ObterPorEmail(string email)
        {
            return (from pessoaJuridica in dbContext.PessoaJuridicas
                    join fornecedorCliente in dbContext.ClienteFornecedors on pessoaJuridica.ID equals fornecedorCliente.ID_PF
                    join contato in dbContext.Contatoes on fornecedorCliente.ID equals contato.ID_PessoaJuridica
                    where contato.Email == email
                    select pessoaJuridica).FirstOrDefault();
        }

        public PessoaJuridica ObterPorCNPJ(string cnpj)
        {
            return dbContext.PessoaJuridicas.FirstOrDefault(x => x.CNPJ == cnpj);
        }
        public List<PessoaJuridica> ObterTodos()
        {
            var clientes = dbContext.PessoaJuridicas.ToList();
            if (clientes.Count() > 0)
            {
                return clientes;
            }
            else
            {
                return null;
            }
        }

        public Empresa ObterEmpresaDefault()
        {
            var empresa = dbContext.Empresas.Where(x => x.CNPJ == "0").FirstOrDefault();
            if (empresa != null)
            {
                return empresa;
            }
            else
            {
                var emp = new Empresa();
                var end = new Endereco();
                emp.CNPJ = "0";
                emp.Nome = "0";
                emp.RazaoSocial = "0";
                /*end.Endereco1 = "0";
                end.Numero = "0";
                end.Complemento = "0";
                end.Bairro = "0";
                end.Cidade = "0";
                end = dbContext.Enderecoes.Add(end);
                List<Endereco> e = new List<Endereco>();
                e.Add(end);
                emp.Enderecoes = e;*/
                emp = dbContext.Empresas.Add(emp);
                dbContext.SaveChanges();
                return emp;
            }
        }

        public PessoaJuridica CadastraPJ(PessoaJuridica pj, Contato cont, Endereco end)
        {
            var pessoa = new PessoaJuridica();
            pessoa = dbContext.PessoaJuridicas.Add(pj);
            if (end != null)
            {
                end.PessoaJuridica = pessoa;
                dbContext.Enderecoes.Add(end);
            }
            if (cont != null)
            {
                cont.PessoaJuridica = pessoa;
                dbContext.Contatoes.Add(cont);
            }
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            return pessoa;
        }

        public PessoaJuridica EditaPJ(PessoaJuridica pj, Contato cont, Endereco end)
        {
            var pessoa = dbContext.PessoaJuridicas.Find(pj.ID);
            pessoa.Nome = pj.Nome;
            pessoa.RazaoSocial = pj.RazaoSocial;
            pessoa.CNPJ = pj.CNPJ;
            try
            {
                if (end != null)
                {
                    var e = BuscaEndereco(pessoa.ID);
                    if (e != null)
                    {
                        e.Endereco1 = end.Endereco1;
                        e.Numero = end.Numero;
                        e.Complemento = end.Complemento;
                        e.Bairro = end.Bairro;
                        e.Cidade = end.Cidade;
                        e.CEP = end.CEP;
                    }
                    else
                    {
                        end.PessoaJuridica = pessoa;
                        dbContext.Enderecoes.Add(end);
                    }
                }
                else
                {
                    var e = BuscaEndereco(pessoa.ID);
                    if (e != null)
                    {
                        dbContext.Enderecoes.Remove(e);
                    }
                }

                if (cont != null)
                {
                    var c = BuscaContato(pessoa.ID);
                    if (c != null)
                    {
                        c.Fone = cont.Fone;
                        c.Email = cont.Email;
                        c.Cargo = cont.Cargo;
                    }
                    else
                    {
                        cont.PessoaJuridica = pessoa;
                        dbContext.Contatoes.Add(cont);
                    }
                }
                else
                {
                    var c = BuscaContato(pessoa.ID);
                    if (c != null)
                    {
                        dbContext.Contatoes.Remove(c);
                    }
                }

                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            return pessoa;
        }

        public Endereco BuscaEndereco(int idPj)
        {
            var end = dbContext.Enderecoes.Where(x => x.ID_PessoaJuridica == idPj).FirstOrDefault();
            if (end != null)
            {
                return end;
            }
            return null;
        }
        public Contato BuscaContato(int idPj)
        {
            var cont = dbContext.Contatoes.Where(x => x.ID_PessoaJuridica == idPj).FirstOrDefault();
            if (cont != null)
            {
                return cont;
            }
            return null;
        }
        public void ExcluiEndereco(int idPj)
        {
            var end = dbContext.Enderecoes.Where(x => x.ID_PessoaJuridica == idPj).FirstOrDefault();
            if (end != null)
            {
                dbContext.Enderecoes.Remove(end);
                dbContext.SaveChanges();
            }
        }
        public void ExcluiContato(int idPj)
        {
            var cont = dbContext.Contatoes.Where(x => x.ID_PessoaJuridica == idPj).FirstOrDefault();
            if (cont != null)
            {
                dbContext.Contatoes.Remove(cont);
                dbContext.SaveChanges();
            }
        }
    }
}