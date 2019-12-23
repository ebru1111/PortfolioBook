using PortfolioBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioBook.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        ApplicationDbContext db;
        public MainController()
        {
            db = new ApplicationDbContext();
        }
        [Authorize(Roles ="Admin")]
        // GET: Admin/Main
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Projects ()
        {
            return View(db.Projects.ToList()) ;
        }
        public ActionResult Photos()
        {
            return View(db.Photos.ToList());
        }
        public ActionResult ConfirmProject(int id)
        {
            Project project = db.Projects.Find(id);
            project.Confirmed = true;
            db.SaveChanges();
            return RedirectToAction ("Index", "Main");
        }
        public ActionResult UnconfirmProject(int id)
        {
            Project project = db.Projects.Find(id);
            project.Confirmed = false;
            db.SaveChanges();
            return RedirectToAction("Index", "Main");
        }
        public ActionResult ConfirmPhoto(int id)
        {
            Photo photo = db.Photos.Find(id);
            photo.Confirmed = true;
            db.SaveChanges();
            return RedirectToAction("Index", "Main");
        }
        public ActionResult UnconfirmPhoto(int id)
        {
            Photo photo = db.Photos.Find(id);
            photo.Confirmed = false;
            db.SaveChanges();
            return RedirectToAction("Index", "Main");
        }
    }
}