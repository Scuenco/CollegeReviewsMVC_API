using CollegeReviewMVC_API.Adapters.Adapters;
using CollegeReviewMVC_API.Adapters.Interfaces;
using CollegeReviewMVC_API.Model;
using CollegeReviewMVC_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollegeReviewMVC_API.Controllers
{
    public class apiReviewsController : ApiController
    {
        private IReviewAdapter _adapter;
        public apiReviewsController()
        {
            _adapter = new ReviewAdapter();
        }
        public apiReviewsController(IReviewAdapter a)
        {
            _adapter = a;
        }
        public IHttpActionResult Get() 
        {
            List<ReviewViewModel> model =  _adapter.GetAllReviews();
            return Ok(model);
        }
        [System.Web.Http.HttpPut]
        [Route("api/apiReviews/Edit")]
        public IHttpActionResult Edit(Review model) 
        {
            int result = _adapter.EditReview(model);
            if (result == 1) return Ok(model);
            else return BadRequest();
        }

        public IHttpActionResult Delete(int id)
        {
            int result = _adapter.DeleteReview(id);
            if (result == 1) return Ok();
            else return BadRequest();
        }
    }
}
