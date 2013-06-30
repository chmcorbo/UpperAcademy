using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Persistence.nHibernate.Repositorio;

namespace UpperAcademy.Web.Controllers
{
    public class AlunoController : Controller
    {
        //
        // GET: /Aluno/
        private RepositorioAluno repositorio = new RepositorioAluno();

        public ActionResult Listar()
        {
            return View(repositorio.ListarTudo());
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            ViewBag.Head1 = "Adicionar novo aluno";
            Aluno aluno = new Aluno();
            aluno.DefinirEndereco(new EnderecoAluno(aluno));
            aluno.CriarTelefonesPadrao();
            return View(aluno);
        }

        [HttpPost]
        public ActionResult Adicionar(Aluno aluno)
        {
            repositorio.Adicionar(aluno);
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Editar(Guid ID)
        {
            ViewBag.Head1 = "Editar aluno";
            Aluno aluno = repositorio.ObterPorID(ID.ToString());
            return View("Adicionar", aluno);
        }

        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            repositorio.Atualizar(aluno);
            return RedirectToAction("Listar");
        }

        public ActionResult Excluir(Guid ID)
        {
            Aluno aluno = repositorio.ObterPorID(ID.ToString());

            repositorio.Excluir(aluno);

            return RedirectToAction("Listar");
        }

        public ActionResult Detalhar(Guid ID)
        {
            Aluno aluno = repositorio.ObterPorID(ID.ToString());

            return View("Detalhar",aluno);
        }
    }
}
