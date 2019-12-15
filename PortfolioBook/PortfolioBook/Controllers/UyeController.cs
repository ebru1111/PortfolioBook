using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PortfolioBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioBook.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        ApplicationDbContext db;
        public UyeController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var uyeler = db.Users.Select(x => new UyeViewModel { UyeID = x.Id, KullaniciAdi = x.UserName }).ToList();

            return View(uyeler);
        }

        public ActionResult RolAta(string id)
        {
            var userManager = HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            var user = userManager.FindById(id);

            if (user == null)
                return HttpNotFound();

            ViewBag.Roles = db.Roles.ToList();
            return View(user);
        }

        [HttpPost]
        public ActionResult RolAta(string userId, string[] roles)
        {
            var userManager = HttpContext.GetOwinContext().Get<ApplicationUserManager>();

            // yeni rollere kullanıcıyı bağlamadan önce, kullanıcının üzerindeki tüm rolleri kopartıyoruz:
            userManager.RemoveFromRoles(userId, userManager.GetRoles(userId).ToArray());

            if (roles != null)
            {
                foreach (var item in roles)
                {
                    userManager.AddToRole(userId, item);
                }
            }

            return RedirectToAction("Index");
        }
    }
}