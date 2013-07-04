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
    public class EmprestimoController : Controller
    {
        //
        // GET: /Emprestimo/

        private EmprestimoMidia emprestimoMidia;
        private RepositorioAluno repositorioAluno = new RepositorioAluno();
        private RepositorioGenerico<Midia> repositorioMidia = new RepositorioGenerico<Midia>();
        private ServEmprestarMidia servEmprestarMidia = new ServEmprestarMidia();

        [HttpGet]
        public ActionResult EscolherAluno()
        {
            emprestimoMidia = new EmprestimoMidia();
            emprestimoMidia.Data_Emprestimo = DateTime.Now.Date;
            Session.Add("emprestimoMidia", emprestimoMidia);
            return View(repositorioAluno.ListarTudo());
        }


        public ActionResult AlterarAluno()
        {
            return View("EscolherAluno", repositorioAluno.ListarTudo());
        }

        
        public ActionResult SelecionarAluno(String pID_Aluno)
        {
            emprestimoMidia = (EmprestimoMidia)Session["emprestimoMidia"];
            emprestimoMidia.Aluno = repositorioAluno.ObterPorID(pID_Aluno);
            Session["emprestimoMidia"] = emprestimoMidia;
            return RedirectToAction("EscolherMidia");
        }

        [HttpGet]
        public ActionResult EscolherMidia()
        {
            return View(repositorioMidia.ListarTudo());
        }


        public ActionResult SelecionarMidia(String pID_Midia)
        {
            emprestimoMidia = (EmprestimoMidia)Session["emprestimoMidia"];
            emprestimoMidia.Midia = repositorioMidia.ObterPorID(pID_Midia);
            Session["emprestimoMidia"] = emprestimoMidia;
            return RedirectToAction("ConfirmarEmprestimo");
        }

        [HttpGet]
        public ActionResult ConfirmarEmprestimo()
        {
            emprestimoMidia = (EmprestimoMidia)Session["emprestimoMidia"];
            return View(emprestimoMidia);
        }

        public ActionResult GravarEmprestimo()
        {
            emprestimoMidia = (EmprestimoMidia)Session["emprestimoMidia"];
            Aluno aluno = emprestimoMidia.Aluno;
            Midia midia = emprestimoMidia.Midia;
            DateTime data_Emprestimo = emprestimoMidia.Data_Emprestimo.Value;

            servEmprestarMidia.Executar(midia,aluno,data_Emprestimo);
            return RedirectToAction("EscolherAluno");
        }

        public ActionResult Cancelar()
        {
            return RedirectToRoute("home/Index");
        }
    }
}
