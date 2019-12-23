using Microsoft.AspNet.Identity;
using PortfolioBook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioBook.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
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
        public ActionResult Profile()
        {
            ViewBag.Message = "Your contact page.";
            string loggedInUserID = User.Identity.GetUserId();
            return View(db.Projects.Where(x => x.ApplicationUserID == loggedInUserID).ToList());
        }
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(Project project)
        {
            string loggedInUserID = User.Identity.GetUserId();
            project.ApplicationUserID = loggedInUserID;
            project.RealeseDate = DateTime.Now;
            project.Confirmed = false;
            db.Projects.Add(project);
            db.SaveChanges();
            ViewBag.Message = "Your contact page.";

            return RedirectToAction("Profile", "Home");
        }
        public ActionResult EditProject(int id)
        {
            return View(db.Projects.Find(id));
        }
        [HttpPost]
        public ActionResult EditProject(int id, string projectName)
        {
            Project project = db.Projects.Find(id);
            project.ProjectName = projectName;
            db.SaveChanges();
            return RedirectToAction("Project", new { id = id });
        }
        public ActionResult DeleteProject(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Profile", "Home");
        }
        public ActionResult Project(int id)
        {
            return View(db.Projects.Where(x => x.ProjectID == id).FirstOrDefault());
        }
        public ActionResult AddPhoto(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddPhoto(Photo photo, int id)
        {
            string fileName = Path.GetFileNameWithoutExtension(photo.ImageFile.FileName);
            string extension = Path.GetExtension(photo.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            photo.ImageUrl = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            photo.ImageFile.SaveAs(fileName);
            photo.ProjectID = id;
            photo.Confirmed = false;
            db.Photos.Add(photo);
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Project", "Home", new { id = id });
        }
        public ActionResult EditPhoto(int id)
        {
            return View(db.Photos.Find(id));
        }
        [HttpPost]
        public ActionResult EditPhoto(int id, string altText)
        {
            Photo photo = db.Photos.Find(id);
            photo.AltText = altText;
            db.SaveChanges();
            return RedirectToAction("Photo", "Home", new { id = id });
        }
        public ActionResult DeletePhoto(int id)
        {
            Photo photo = db.Photos.Find(id);
            int projectId = photo.ProjectID;
            db.Photos.Remove(photo);
            db.SaveChanges();
            return RedirectToAction("Project", "Home", new { id = projectId });
        }
        public ActionResult Photo(int id)
        {
            return View(db.Photos.Find(id));
        }
        public ActionResult AddProjectComment(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddProjectComment(int id, ProjectComment projectComment)
        {
            projectComment.ApplicationUserID = User.Identity.GetUserId();
            projectComment.ProjectID = id;
            db.ProjectComments.Add(projectComment);
            db.SaveChanges();
            return RedirectToAction("Project", "Home",new { id=id });
        }
        public ActionResult DeleteProjectComment(int id)
        {
            ProjectComment projectComment = db.ProjectComments.Find(id);
            int projectId = projectComment.ProjectID;
            db.ProjectComments.Remove(projectComment);
            db.SaveChanges();
            return RedirectToAction("Project", "Home",new { id = projectId });
        }
        public ActionResult AddPhotoComment(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddPhotoComment(int id, PhotoComment photoComment)
        {
            photoComment.ApplicationUserID = User.Identity.GetUserId();
            photoComment.PhotoID = id;
            db.PhotoComments.Add(photoComment);
            db.SaveChanges();
            return RedirectToAction("Photo", "Home",new { id = id });
        }
        public ActionResult DeletePhotoComment(int id)
        {
            PhotoComment photoComment = db.PhotoComments.Find(id);
            int photoId = photoComment.PhotoID;
            db.PhotoComments.Remove(photoComment);
            db.SaveChanges();
            return RedirectToAction("Photo", "Home",new { id = photoId });
        }
        public ActionResult AddStar1(int id)
        {
            string loggedUserId = User.Identity.GetUserId();
            ProjectStar projectStar = db.ProjectStars.Where(x => x.ProjectID == id && x.ApplicationUserID == loggedUserId).FirstOrDefault();
            if (projectStar == null)
            {
                projectStar = new ProjectStar();
                projectStar.ApplicationUserID = User.Identity.GetUserId();
                projectStar.ProjectID = id;
                projectStar.Star = 1;
                db.ProjectStars.Add(projectStar);
                db.SaveChanges();
            }
            else
            {
                projectStar.Star = 1;
                db.SaveChanges();
            }
            return RedirectToAction("Project", "Home",new { id = id });
        }
        public ActionResult AddStar2(int id)
        {
            string loggedUserId = User.Identity.GetUserId();
            ProjectStar projectStar = db.ProjectStars.Where(x => x.ProjectID == id && x.ApplicationUserID == loggedUserId).FirstOrDefault();
            if (projectStar == null)
            {
                projectStar = new ProjectStar();
                projectStar.ApplicationUserID = User.Identity.GetUserId();
                projectStar.ProjectID = id;
                projectStar.Star = 2;
                db.ProjectStars.Add(projectStar);
                db.SaveChanges();
            }
            else
            {
                projectStar.Star = 2;
                db.SaveChanges();
            }
            return RedirectToAction("Project", "Home", new { id = id });
        }
        public ActionResult AddStar3(int id)
        {
            string loggedUserId = User.Identity.GetUserId();
            ProjectStar projectStar = db.ProjectStars.Where(x => x.ProjectID == id && x.ApplicationUserID == loggedUserId).FirstOrDefault();
            if (projectStar == null)
            {
                projectStar = new ProjectStar();
                projectStar.ApplicationUserID = User.Identity.GetUserId();
                projectStar.ProjectID = id;
                projectStar.Star = 3;
                db.ProjectStars.Add(projectStar);
                db.SaveChanges();
            }
            else
            {
                projectStar.Star = 3;
                db.SaveChanges();
            }
            return RedirectToAction("Project", "Home", new { id = id });
        }
        public ActionResult AddStar4(int id)
        {
            string loggedUserId = User.Identity.GetUserId();
            ProjectStar projectStar = db.ProjectStars.Where(x => x.ProjectID == id && x.ApplicationUserID == loggedUserId).FirstOrDefault();
            if (projectStar == null)
            {
                projectStar = new ProjectStar();
                projectStar.ApplicationUserID = User.Identity.GetUserId();
                projectStar.ProjectID = id;
                projectStar.Star = 4;
                db.ProjectStars.Add(projectStar);
                db.SaveChanges();
            }
            else
            {
                projectStar.Star = 4;
                db.SaveChanges();
            }
            return RedirectToAction("Project", "Home", new { id = id });
        }
        public ActionResult AddStar5(int id)
        {
            string loggedUserId = User.Identity.GetUserId();
            ProjectStar projectStar = db.ProjectStars.Where(x => x.ProjectID == id && x.ApplicationUserID == loggedUserId).FirstOrDefault();
            if (projectStar == null)
            {
                projectStar = new ProjectStar();
                projectStar.ApplicationUserID = User.Identity.GetUserId();
                projectStar.ProjectID = id;
                projectStar.Star = 5;
                db.ProjectStars.Add(projectStar);
                db.SaveChanges();
            }
            else
            {
                projectStar.Star = 5;
                db.SaveChanges();
            }
            return RedirectToAction("Project", "Home", new { id = id });
        }
    }
}