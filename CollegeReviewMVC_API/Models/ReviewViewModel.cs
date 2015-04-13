using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeReviewMVC_API.Models
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public bool IsDeleted { get; set; }
    }
}