using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Persistence.nHibernate.Repositorio;

namespace UpperAcademy.Web.Controllers
{
    public class TurmaController : Controller
    {
        //
        // GET: /Tuma/

        private RepositorioGenerico<Turma> repositorio = new RepositorioGenerico<Turma>();

        public ActionResult Listar()
        {
            return View(repositorio.ListarTudo());
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            Turma turma = new Turma();
            return View(turma);
        }

        [HttpPost]
        public ActionResult Adicionar(Turma turma)
        {
            repositorio.Adicionar(turma);
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Editar(Guid ID)
        {
            Turma turma = repositorio.ObterPorID(ID.ToString());
            return View("Editar", turma);
        }

        [HttpPost]
        public ActionResult Editar(Turma turma)
        {
            repositorio.Atualizar(turma);
            return RedirectToAction("Listar");
        }

        public ActionResult Excluir(Guid ID)
        {
            Turma turma = repositorio.ObterPorID(ID.ToString());

            repositorio.Excluir(turma);

            return RedirectToAction("Listar");
        }

        public ActionResult Detalhar(Guid ID)
        {
            Turma turma = repositorio.ObterPorID(ID.ToString());

            return View("Detalhar", turma);
        }

    }
}
