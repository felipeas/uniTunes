using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitunesMvc.Models;
using UnitunesMvc.Core.Database.Entities;
using System.Web.Security;

namespace UnitunesMvc.Controllers
{
    public class LoginController : Controller
    {
        private UnitunesEntities db = new UnitunesEntities();
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Form is not valid; please review and try again.";
                return View("Login");
            }

            var v = db.Usuarios.Where(a => a.Email.Equals(login.Email ) && a.Senha.Equals(login.Senha)).FirstOrDefault();
            if (v != null)
            {
                FormsAuthentication.RedirectFromLoginPage(login.Email, true);
       
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Usuário ou senha inválidos. Tente novamente";
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}