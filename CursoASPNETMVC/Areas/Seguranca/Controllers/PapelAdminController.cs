using CursoASPNETMVC.Areas.Seguranca.Models;
using CursoASPNETMVC.Infraestrutura;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoASPNETMVC.Areas.Seguranca.Controllers
{
    public class PapelAdminController : Controller
    {
        private GerenciadorPapel RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager
                <GerenciadorPapel>();
            }
        }
        // GET: Seguranca/PapelAdmin
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        private GerenciadorUsuario UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().
                GetUserManager<GerenciadorUsuario>();
            }
        }
        [HttpPost]
        public ActionResult Create([Required] string nome)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = RoleManager.Create(new Papel(nome));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(nome);
        }
    }
}