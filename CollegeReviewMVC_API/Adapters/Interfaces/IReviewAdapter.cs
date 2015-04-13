using CollegeReviewMVC_API.Model;
using CollegeReviewMVC_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeReviewMVC_API.Adapters.Interfaces
{
    public interface IReviewAdapter
    {
        List<ReviewViewModel> GetAllReviews();
        int EditReview(Review model);
        int DeleteReview(int id);
    }
}
