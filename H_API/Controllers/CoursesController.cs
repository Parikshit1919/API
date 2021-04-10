using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using H_API.Models;

namespace H_API.Controllers
{
    public class CoursesController : ApiController
    {
        //CREATE ENTITIY OBJECT
        Online_examEntities db = new Online_examEntities();

        [HttpGet]
        public IHttpActionResult Get()
        {
           var courses =  db.Courses.ToList();
            return Ok(courses);
        }
    }
}
