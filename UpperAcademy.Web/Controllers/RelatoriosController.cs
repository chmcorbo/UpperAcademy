using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using UpperAcademy.Dominio.Modelo;

namespace UpperAcademy.Web.Controllers
{
    public class RelatoriosController : Controller
    {
        //
        // GET: /Relatorios/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MidiasEmprestadas()
        {
            RepositorioEmprestimoMidia repositorioEmprestimoMidia = new RepositorioEmprestimoMidia();
            List<EmprestimoMidia> lista = repositorioEmprestimoMidia.ListarEmprestimos().ToList();
            return View(lista.OrderBy(e => e.Midia.Descricao));
        }


    }
}
