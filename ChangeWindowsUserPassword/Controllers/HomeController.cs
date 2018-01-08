using ChangeWindowsUserPassword.ViewModels;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeWindowsUserPassword.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ChangePasswordVM model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new PrincipalContext(ContextType.Machine))
                using (var user = UserPrincipal.FindByIdentity(context, User.Identity.Name))
                {
                    user.ChangePassword(model.OldPassword, model.NewPassword);
                }

                return RedirectToAction("About");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Password is changed!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}