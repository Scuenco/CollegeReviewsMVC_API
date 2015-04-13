using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeReviewMVC_API.Model
{
    public class College
    {
        public int CollegeId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int ReviewId { get; set; }
        public virtual List<Review> Reviews { get; set; }
    }
}
