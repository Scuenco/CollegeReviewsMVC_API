using CollegeReviewMVC_API.Adapters.Interfaces;
using CollegeReviewMVC_API.Data;
using CollegeReviewMVC_API.Model;
using CollegeReviewMVC_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeReviewMVC_API.Adapters.Adapters
{
    public class ReviewAdapter : IReviewAdapter
    {
        List<ReviewViewModel> model;
        public List<Models.ReviewViewModel> GetAllReviews()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Reviews.Select(x => new ReviewViewModel()
                    {
                        ReviewId = x.ReviewId,
                        Description = x.Description,
                        Rating = x.Rating.ToString()
                    }).ToList();
            }
            return (model);
        }
        public int EditReview(Review review)
        {
            int result;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                Review model = db.Reviews.FirstOrDefault(x => x.ReviewId == review.ReviewId);
                model.Description = review.Description;
                model.Rating = review.Rating;
                result = db.SaveChanges();
            }
            return result;
        }

        public int DeleteReview(int id)
        {
            int result;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                Review model = db.Reviews.FirstOrDefault(x => x.ReviewId == id);
                model.IsDeleted = true;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}