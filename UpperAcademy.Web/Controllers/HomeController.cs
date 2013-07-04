using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UpperAcademy.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Aluno()
        {
            return RedirectToRoute("Aluno");
        }

        public ActionResult Sair()
        {
            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Autenticar", "Login");
        }
    }
}
