using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using H_API.Models;
using System.Data.Entity;

namespace H_API.Controllers
{
    public class FeedBackController : ApiController
    {
        //CREATE ENTITIY OBJECT
        Online_examEntities db = new Online_examEntities();

        //METHOD TO GET FEEDBACKS
        [HttpGet]
        public IHttpActionResult Get()
        {
            var feedbacks = db.GET_FEEDBACK1(); //CALLING STORED PROCEDURE TO GET FEEDBACK
            return Ok(feedbacks);
        }

        //METHOD TO ADD FEEDBACK
        [HttpPost]
        public IHttpActionResult Post(Feedback feedback)
        {
            //CHECK IF STUDENT IS TRYING TO GIVE FEEDBACK FOR AN EAM WHICH HE HAS NOT GIVIN
            var check = db.Results.Where(a => a.e_id == feedback.e_id && a.s_id == feedback.s_id).FirstOrDefault();
            if(check==null)
            {
                return Ok("error");
            }
            try
            {
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                return Ok("added");
            }
 
            catch(Exception e)
            {
                return Ok("error");
            }
        }
    }
}
