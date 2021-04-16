using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using H_API.Models;

namespace H_API.Controllers
{
    public class StudentController : ApiController
    {
        //CREATE ENTITIY OBJECT
        Online_examEntities db = new Online_examEntities();

        [Route("api/Student/GetByEmail")]
        [HttpGet]
        public IHttpActionResult GetByEmail(string email)
        {
            var student = db.View_Student_ByEmail(email).FirstOrDefault();
            return Ok(student);
        }
    }
}
