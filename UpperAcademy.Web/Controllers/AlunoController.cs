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

        public ActionResult Listar()
        {
            RepositorioGenerico<Aluno> repositorio = new RepositorioGenerico<Aluno>();

            return View(repositorio.ListarTudo());
        }

    }
}
