using PortfolioBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioBook.Areas.Moderator.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class DefaultController : Controller
    {
        ApplicationDbContext db;
        public DefaultController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Moderator/Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProjectComment ()
        {
            return View(db.ProjectComments.ToList());
        }
        public ActionResult DeleteProjectComment (int id)
        {
            ProjectComment projectComment = db.ProjectComments.Find(id);
            db.ProjectComments.Remove(projectComment);
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}