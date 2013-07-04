using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using UpperAcademy.Persistence.nHibernate.Servicos;

namespace UpperAcademy.Web.Controllers
{
    public class DevolucaoController : Controller
    {
        //
        // GET: /Devolucao/

        private RepositorioEmprestimoMidia repositorioEmprestimoMidia = new RepositorioEmprestimoMidia();
        private ServDevolverMidia servDevolverMidia = new ServDevolverMidia();

        public ActionResult Listar()
        {
            List<EmprestimoMidia> listaEmprestimos = repositorioEmprestimoMidia.ListarEmprestimos().ToList();
            return View(listaEmprestimos);
        }

        [HttpGet]
        public ActionResult SolicitarConfirmacaoDevolucao(String pID_Emprestimo)
        {
            EmprestimoMidia emprestimoMidia = repositorioEmprestimoMidia.ObterPorID(pID_Emprestimo);
            emprestimoMidia.Data_Devolucao = DateTime.Now;
            Session["emprestimoMidia"] = emprestimoMidia;
            return View(emprestimoMidia);
        }

        [HttpPost]
        public ActionResult SolicitarConfirmacaoDevolucao()
        {
            EmprestimoMidia emprestimoMidia = (EmprestimoMidia)Session["emprestimoMidia"];
            servDevolverMidia.Executar(emprestimoMidia.Midia.ID, emprestimoMidia.Data_Devolucao.Value);
            return RedirectToAction("Listar");
        }

    }
}
