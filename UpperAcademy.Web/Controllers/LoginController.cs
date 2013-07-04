using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UpperAcademy.Web.Models;

namespace UpperAcademy.Web.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Autenticar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autenticar(LoginViewModel pLoginViewModel, String pRedirectURL)
        {
            if (ModelState.IsValid)
            {
                if (FormsAuthentication.Authenticate(pLoginViewModel.Login,pLoginViewModel.Senha))
                {
                    FormsAuthentication.SetAuthCookie(pLoginViewModel.Login, false);
                    return Redirect(pRedirectURL ?? Url.Action("Index","Home"));
                }
                ModelState.AddModelError("","Usuário ou senha não é válido");
            }
            return View();
        }
    }
}
