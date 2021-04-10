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

        //METHOD TO GET ADD FEEDBACKS
        [HttpGet]
        public IHttpActionResult Get()
        {
            var feedbacks = db.GET_FEEDBACK1(); //CALLING STORED PROCEDURE TO GET FEEDBACK
            return Ok(feedbacks);
        }

        //
    }
}
