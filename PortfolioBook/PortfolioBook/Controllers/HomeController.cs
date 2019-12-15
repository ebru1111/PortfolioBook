using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }  
        public ActionResult Register()
        {
            return View();
        } 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Projects()
        {
            return View();
        }
        public ActionResult ProjeGorunumu2()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        } 
        public ActionResult ImageViews()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}