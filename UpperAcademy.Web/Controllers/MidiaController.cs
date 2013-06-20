using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Persistence.nHibernate.Repositorio;

namespace UpperAcademy.Web.Controllers
{
    public class MidiaController : Controller
    {
        //
        // GET: /Midia/

        private RepositorioGenerico<Midia> repositorio = new RepositorioGenerico<Midia>();

        public ActionResult Listar()
        {
            return View(repositorio.ListarTudo());
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            Midia midia = new Midia();
            return View(midia);
        }

        [HttpPost]
        public ActionResult Adicionar(Midia midia)
        {
            midia.Qtde_Disponivel = midia.Qtde_Copias;
            repositorio.Adicionar(midia);
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Editar(Guid ID)
        {
            Midia midia = repositorio.ObterPorID(ID.ToString());
            return View("Editar", midia);
        }

        [HttpPost]
        public ActionResult Editar(Midia midia)
        {
            repositorio.Atualizar(midia);
            return RedirectToAction("Listar");
        }

        public ActionResult Excluir(Guid ID)
        {
            Midia midia = repositorio.ObterPorID(ID.ToString());

            repositorio.Excluir(midia);

            return RedirectToAction("Listar");
        }

        public ActionResult Detalhar(Guid ID)
        {
            Midia midia = repositorio.ObterPorID(ID.ToString());

            return View("Detalhar", midia);
        }

    }
}
