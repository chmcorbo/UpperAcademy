using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Persistence.nHibernate.Repositorio;

namespace UpperAcademy.Web.Controllers
{
    public class ProfessorController : Controller
    {
        // Analisar Futuramente a possibilidade de criar controllers mais abstratos para evitar a repetição de códigos;

        // GET: /Professor/

        private RepositorioGenerico<Professor> repositorio = new RepositorioGenerico<Professor>();

        public ActionResult Listar()
        {
            return View(repositorio.ListarTudo());
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            ViewBag.Head1 = "Adicionar novo professor";
            Professor professor = new Professor();
            professor.DefinirEndereco(new EnderecoProfessor(professor));
            professor.CriarTelefonesPadrao();
            return View(professor);
        }

        [HttpPost]
        public ActionResult Adicionar(Professor professor)
        {
            repositorio.Adicionar(professor);
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Editar(Guid ID)
        {
            ViewBag.Head1 = "Editar professor";
            Professor professor = repositorio.ObterPorID(ID.ToString());
            return View("Adicionar", professor);
        }

        [HttpPost]
        public ActionResult Editar(Professor professor)
        {
            repositorio.Atualizar(professor);
            return RedirectToAction("Listar");
        }

        public ActionResult Excluir(Guid ID)
        {
            Professor professor = repositorio.ObterPorID(ID.ToString());

            repositorio.Excluir(professor);

            return RedirectToAction("Listar");
        }

        public ActionResult Detalhar(Guid ID)
        {
            Professor professor = repositorio.ObterPorID(ID.ToString());

            return View("Detalhar", professor);
        }

    }
}
