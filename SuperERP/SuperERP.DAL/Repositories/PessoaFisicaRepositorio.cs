using SuperERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperERP.DAL.Repositories
{
    public class PessoaFisicaRepositorio : Repositorio<PessoaFisica>
    {
        public PessoaFisica ObterPorEmail(string email)
        {
            return (from pessoaFisica in dbContext.PessoaFisicas
                    join fornecedorCliente in dbContext.ClienteFornecedors on pessoaFisica.ID equals fornecedorCliente.ID_PF
                    join contato in dbContext.Contatoes on fornecedorCliente.ID equals contato.ID_PessoaJuridica
                    where contato.Email == email
                    select pessoaFisica).FirstOrDefault();
        }

        public PessoaFisica ObterPorCPF(string cpf)
        {
            return dbContext.PessoaFisicas.FirstOrDefault(x => x.CPF == cpf);
        }

        public List<PessoaFisica> ObterTodos()
        {
            //var clientes = (from pessoaFisica in dbContext.PessoaFisicas select pessoaFisica).ToList();
            var clientes = dbContext.PessoaFisicas.ToList();
            if (clientes.Count() > 0)
            {
                return clientes;
            }
            else
            {
                return null;
            }
        }

        public List<Empresa> ObterEmpresas()
        {
            var empresas = new List<Empresa>();
            empresas = dbContext.Empresas.ToList();
            if (empresas != null)
            {
                return empresas;
            }
            return null;
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
                //var end = new Endereco();
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
        public PessoaFisica CadastraPF(PessoaFisica pf, Contato cont, Endereco end)
        {
            var pessoa = new PessoaFisica();
            pessoa = dbContext.PessoaFisicas.Add(pf);
            if (end != null)
            {
                end.PessoaFisica = pessoa;
                dbContext.Enderecoes.Add(end);
            }
            if (cont != null)
            {
                cont.PessoaFisica = pessoa;
                dbContext.Contatoes.Add(cont);
            }
            try {
                dbContext.SaveChanges();
            }catch(Exception e)
            {
                System.Console.WriteLine(e);
            }
            return pessoa;
        }

        public PessoaFisica EditaPF(PessoaFisica pf, Contato cont, Endereco end)
        {
            var pessoa = dbContext.PessoaFisicas.Find(pf.ID);
            pessoa.Nome = pf.Nome;
            pessoa.RG = pf.RG;
            pessoa.CPF = pf.CPF;
            try { 
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
                        end.PessoaFisica = pessoa;
                        dbContext.Enderecoes.Add(end);
                    }
                }
                else
                {
                    var e = BuscaEndereco(pessoa.ID);
                    if(e != null)
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
                        cont.PessoaFisica = pessoa;
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

        public Endereco BuscaEndereco(int idPf)
        {
            var end = dbContext.Enderecoes.Where(x => x.ID_PessoaFisica == idPf).FirstOrDefault();
            if(end != null)
            {
                return end;
            }
            return null;
        }
        public Contato BuscaContato(int idPf)
        {
            var cont = dbContext.Contatoes.Where(x => x.ID_PessoaFisica == idPf).FirstOrDefault();
            if (cont != null)
            {
                return cont;
            }
            return null;
        }
        public void ExcluiEndereco(int idPf)
        {
            var end = dbContext.Enderecoes.Where(x => x.ID_PessoaFisica == idPf).FirstOrDefault();
            if (end != null)
            {
                dbContext.Enderecoes.Remove(end);
                dbContext.SaveChanges();
            }
        }
        public void ExcluiContato(int idPf)
        {
            var cont = dbContext.Contatoes.Where(x => x.ID_PessoaFisica == idPf).FirstOrDefault();
            if (cont != null)
            {
                dbContext.Contatoes.Remove(cont);
                dbContext.SaveChanges();
            }
        }
    }
}
