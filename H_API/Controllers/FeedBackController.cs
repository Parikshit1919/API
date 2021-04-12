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
        Online_examEntities1 db = new Online_examEntities1();

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
             //CHECK IF FEEDBACK ALREADY EXISTS
            var check = db.Feedbacks.Where(f => f.c_id == feedback.c_id && f.level==feedback.level && f.s_name==feedback.s_name).FirstOrDefault();
            //IF FEEDBACK NOT EXISTS ADD NEW RECORD
            if (check == null)
            {
                db.Feedbacks.Add(feedback);
            db.SaveChanges();
            return Ok("added");
            }
            // ELSE RETURN ALREADY EXISTS
            else
            {
                return Ok("exists");
            }


        }
    }
}
