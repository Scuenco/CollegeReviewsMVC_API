using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using CollegeReviewMVC_API.Model;

namespace CollegeReviewMVC_API.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext db, bool seedColleges = false, bool seedReviews = false)
        {
            if (seedColleges) SeedColleges(db);
            if (seedReviews) SeedReviews(db);
        }

        private static void SeedReviews(ApplicationDbContext db)
        {
            db.Colleges.AddOrUpdate(x => x.CollegeId,
                new College() { CollegeId = 1, Name = "Orange Coast College", ReviewId = 1 },
                new College() { CollegeId = 2, Name = "University of Southern California", ReviewId = 2 },
                new College() { CollegeId = 3, Name = "University of California Irvine", ReviewId = 3 },
                new College() { CollegeId = 4, Name = "Don Bosco College", ReviewId = 1 },
                new College() { CollegeId = 5, Name = "Irvine Valley College", ReviewId = 2 },
                new College() { CollegeId = 6, Name = "Baguio Colleges Foundation", ReviewId = 3 }
                );
        }

        private static void SeedColleges(ApplicationDbContext db)
        {
            db.Reviews.AddOrUpdate(x => x.ReviewId,
                new Review() { ReviewId = 1, Description = "It's an excellent college.", Rating = Rating.Excellent, CollegeId = 3 },
                new Review() { ReviewId = 2, Description = "It's an average college.", Rating = Rating.Average, CollegeId = 2 },
                new Review() { ReviewId = 3, Description = "It's a fair college.", Rating = Rating.Fair, CollegeId = 5 },
                new Review() { ReviewId = 4, Description = "It's a good college.", Rating = Rating.Good, CollegeId = 1 }
                );
        }

    }
}
