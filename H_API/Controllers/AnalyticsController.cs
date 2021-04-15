using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using H_API.Models;
namespace H_API.Controllers
{
    public class AnalyticsController : ApiController
    {
        //CREATE ENTITIY OBJECT
        Online_examEntities db = new Online_examEntities();

        //METHOD TO GET ANALYTICS
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(db.View_Analytics().FirstOrDefault());
        }
    }
}
