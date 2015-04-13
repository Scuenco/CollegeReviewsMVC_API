using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeReviewMVC_API.Model
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Description { get; set; }
        public Rating Rating { get; set; }
        public bool IsDeleted { get; set; }
        public int AverageRating(int rating)
        {
            int aveRating = rating;
            return aveRating;
        }

        public int CollegeId { get; set; }
        public virtual College College { get; set; }
    }
    public enum Rating
    {
        Select,
        Poor,
        Fair,
        Average,
        Good,
        Excellent
    }
}
