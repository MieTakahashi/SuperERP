using SuperERP.Vendas.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperERP.Web.Controllers
{
    public class VendasOrcamentosController : Controller
    {
        // GET: VendasOrcamentos
        public ActionResult Index()
        {
            ViewBag.Recusados = 0;
            ViewBag.Orcamentos = 0;
            ViewBag.Aceitos = 0;
            ViewBag.Vendas = 0;
            ViewBag.Previsao = 0;
            return View();
        }

        public ActionResult Novo()
        {
            GerarViewBag();
            return View();
        }

        public ActionResult ExcluirVenda(int id)
        {
            try
            {
                // TODO: Add update logic here
                Vendas.Excluir.Venda(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Novo(VendaContratoDTO vendaContrato)
        {
            return View();
        }

        public ActionResult Visualizar(int id)
        {
            //var listaDeVendasOrcamentos = SuperERP.Vendas.Listar.Venda();
            //return View(listaDeVendasOrcamentos);
            return View();
        }

        private void GerarViewBag()
        {
            ViewBag.Clientes = new SelectList(SuperERP.Vendas.Service.ClienteService.ListarClientes(), "Id", "Nome");             
        }
    }
}