using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperERP.Vendas.Service;
using SuperERP.Vendas.DTO;
using System.Text.RegularExpressions;

namespace SuperERP.Web.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.fisicas = ClienteService.ListaPessoasFisicas();
            ViewBag.juridicas = ClienteService.ListaPessoasJuridicas();
            return View();
        }

        public ActionResult Editar(int id, int tipo)
        {
            if (tipo == 1)
            {
                var pf = ClienteService.BuscaPF(id);
                return View("EditarPF", pf);
            }
            else if (tipo == 2)
            {
                var pj = ClienteService.BuscaPJ(id);
                return View("EditarPJ", pj);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(FormCollection f)
        {
            // Pessoa Fisica
            if (f["pessoa"] == "1")
            {
                var pessoa = new PessoaFisicaDTO();

                pessoa.ID = Convert.ToInt32(f["ID"]);
                pessoa.Nome = f["Nome"];
                pessoa.CPF = new Regex(@"[^\d]").Replace(f["CPF"], "");
                pessoa.RG = new Regex(@"[^\d]").Replace(f["RG"], "");

                if (f["Email"] != null)
                {
                    pessoa.Email = f["Email"];
                    pessoa.Fone = new Regex(@"[^\d]").Replace(f["Fone"], "");
                    pessoa.Cargo = f["Cargo"];
                }

                if (f["Endereco"] != null)
                {
                    pessoa.Endereco = f["Endereco"];
                    pessoa.Numero = f["Numero"];
                    pessoa.Complemento = f["Complemento"];
                    pessoa.CEP = new Regex(@"[^\d]").Replace(f["CEP"], "");
                    pessoa.Bairro = f["Bairro"];
                    pessoa.Cidade = f["Cidade"];
                }
                ClienteService.EditaPessoaFisica(pessoa);
            }
            // Pessoa Juridica
            else if (f["pessoa"] == "2")
            {
                var pessoa = new PessoaJuridicaDTO();
                pessoa.ID = Convert.ToInt32(f["ID"]);
                pessoa.Nome = f["Nome"];
                pessoa.CNPJ = new Regex(@"[^\d]").Replace(f["CNPJ"], "");
                pessoa.RazaoSocial = f["RazaoSocial"];

                if (f["Email"] != null)
                {
                    pessoa.Email = f["Email"];
                    pessoa.Fone = new Regex(@"[^\d]").Replace(f["Fone"], "");
                    pessoa.Cargo = f["Cargo"];
                }

                if (f["Endereco"] != null)
                {
                    pessoa.Endereco = f["Endereco"];
                    pessoa.Numero = f["Numero"];
                    pessoa.Complemento = f["Complemento"];
                    pessoa.CEP = new Regex(@"[^\d]").Replace(f["CEP"], "");
                    pessoa.Bairro = f["Bairro"];
                    pessoa.Cidade = f["Cidade"];
                }
                ClienteService.EditaPessoaJuridica(pessoa);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(FormCollection f)
        {
            // Pessoa Fisica
            if (f["pessoa"] == "1")
            {
                var pessoa = new PessoaFisicaDTO();
                pessoa.Nome = f["Item1.Nome"];
                pessoa.CPF = new Regex(@"[^\d]").Replace(f["Item1.CPF"], "");
                pessoa.RG = new Regex(@"[^\d]").Replace(f["Item1.RG"], "");

                if(f["Item1.Email"] != null)
                {
                    pessoa.Email = f["Item1.Email"];
                    pessoa.Fone = new Regex(@"[^\d]").Replace(f["Item1.Fone"], "");
                    pessoa.Cargo = f["Item1.Cargo"];
                }

                if (f["Item1.Endereco"] != null)
                {
                    pessoa.Endereco = f["Item1.Endereco"];
                    pessoa.Numero = f["Item1.Numero"];
                    pessoa.Complemento = f["Item1.Complemento"];
                    pessoa.CEP = new Regex(@"[^\d]").Replace(f["Item1.CEP"], "");
                    pessoa.Bairro = f["Item1.Bairro"];
                    pessoa.Cidade = f["Item1.Cidade"];
                }
                ClienteService.CadastraPessoaFisica(pessoa);
            }
            // Pessoa Juridica
            else if (f["pessoa"] == "2")
            {
                var pessoa = new PessoaJuridicaDTO();
                pessoa.Nome = f["Item2.Nome"];
                pessoa.CNPJ = new Regex(@"[^\d]").Replace(f["Item2.CNPJ"], "");
                pessoa.RazaoSocial = f["Item2.RazaoSocial"];

                if (f["Item1.Email"] != null)
                {
                    pessoa.Email = f["Item1.Email"];
                    pessoa.Fone = new Regex(@"[^\d]").Replace(f["Item1.Fone"], "");
                    pessoa.Cargo = f["Item1.Cargo"];
                }

                if (f["Item1.Endereco"] != null)
                {
                    pessoa.Endereco = f["Item1.Endereco"];
                    pessoa.Numero = f["Item1.Numero"];
                    pessoa.Complemento = f["Item1.Complemento"];
                    pessoa.CEP = new Regex(@"[^\d]").Replace(f["Item1.CEP"], "");
                    pessoa.Bairro = f["Item1.Bairro"];
                    pessoa.Cidade = f["Item1.Cidade"];
                }
                ClienteService.CadastraPessoaJuridica(pessoa);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Excluir(int id, int tipo)
        {
            ClienteService.ExcluirCliente(id, tipo);
            return RedirectToAction("Index");
        }
    }
}