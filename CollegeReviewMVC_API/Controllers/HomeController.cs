using CollegeReviewMVC_API.Data;
using CollegeReviewMVC_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeReviewMVC_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //display all colleges that are not deleted
            List<College> model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Colleges.Where(x => x.IsDeleted == false).ToList();
            }
            return View(model);
        }

        public ActionResult Details(int id) //id is College Id
        {
            College model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Colleges.Include("Reviews").FirstOrDefault(x => x.CollegeId == id);
            }
            return View(model);
        }
        public ActionResult AddCollege()
        {
            ViewBag.Message = "Add a College";
            return View(new College());
        }

        [HttpPost]
        public ActionResult AddCollege(College model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Colleges.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult EditCollege(int id)
        {
            ViewBag.Message = "Edit a College";
            College model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Colleges.FirstOrDefault(x => x.CollegeId == id);
            }
            return View("AddCollege", model); //shares view w/ AddCollege
        }

        [HttpPost]
        public ActionResult EditCollege(College college)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                College model = db.Colleges.FirstOrDefault(x => x.CollegeId == college.CollegeId);
                model.Name = college.Name;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCollege(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                College model = db.Colleges.FirstOrDefault(x => x.CollegeId == id);
                model.IsDeleted = true;
                //db.Colleges.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddReview(int id) //id is College Id
        {
            ViewBag.Message = "Add a Review";
            Review model = new Review() { 
                CollegeId = id 
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddReview(Review model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Reviews.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction("Details", new { id=model.CollegeId });
        }

        public ActionResult EditReview(int id) //id is Review Id
        {
            ViewBag.Message = "Edit a Review";
            Review model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //model = db.Reviews.Include("College").FirstOrDefault(x => x.ReviewId == id);
                model = db.Reviews.FirstOrDefault(x => x.ReviewId == id);
            }
            return View("AddReview", model); //shares view w/ AddReview
        }

        [HttpPost]
        public ActionResult EditReview(Review review)
        {
            Review model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Reviews.FirstOrDefault(x => x.ReviewId == review.ReviewId);
                model.Description = review.Description;
                model.Rating = review.Rating;
                //model.AverageRating(model.Rating);
                db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = model.CollegeId });
        }
        public ActionResult DeleteReview(int id) //id is Review Id
        {
            Review model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Reviews.FirstOrDefault(x => x.ReviewId == id);
                model.IsDeleted = true;
                db.Reviews.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = model.CollegeId });
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
    }
}