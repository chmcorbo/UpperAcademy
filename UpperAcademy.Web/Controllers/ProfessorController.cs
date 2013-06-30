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

        private void CarregarListaDeNiveis(Professor pProfessor)
        {
            UpperAcademy.Dominio.Servicos.ServListaFixaNivel servListaFixaNivel = new Dominio.Servicos.ServListaFixaNivel();
            Int32 co = 1;
            IEnumerable<SelectListItem> niveis = servListaFixaNivel.Listar().Select(n =>
                new SelectListItem
                {
                    Selected = (pProfessor.Nivel == co),
                    Value = co++.ToString(),
                    Text = n
                });
            ViewBag.ListaNiveis = niveis;
        }

        private Int16 ObterNivelSelecionado(FormCollection pForm)
        {
            Int16 resultado = 1;
            String _nivelSelecionado = pForm["ListaNiveis"];
            if (_nivelSelecionado != String.Empty)
            {
                Int16 idNivel = Int16.Parse(_nivelSelecionado);
                resultado = idNivel;
            }
            return resultado;
        }


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
            CarregarListaDeNiveis(professor);
            return View(professor);
        }


        [HttpPost]
        public ActionResult Adicionar(Professor professor, FormCollection form)
        {
            professor.Nivel = ObterNivelSelecionado(form);
            repositorio.Adicionar(professor);
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Editar(Guid ID)
        {
            ViewBag.Head1 = "Editar professor";
            Professor professor = repositorio.ObterPorID(ID.ToString());
            CarregarListaDeNiveis(professor);
            return View("Adicionar", professor);
        }

        [HttpPost]
        public ActionResult Editar(Professor professor, FormCollection form)
        {
            professor.Nivel = ObterNivelSelecionado(form);

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
