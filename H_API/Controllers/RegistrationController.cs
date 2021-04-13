using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using H_API.Models;

namespace H_API.Controllers
{
    public class RegistrationController : ApiController
    {
        //CREATE ENTITIY OBJECT
        Online_examEntities db = new Online_examEntities();

        //METHOD TO ADD NEW RECORDS INTO STUDENT TABLE
        [HttpPost]
        public IHttpActionResult Post([FromBody] Student student)
        {
            //CHECK IF STUDENT ALREADY REGISTERED
            var check = db.Students.Where(a => a.Student_Email == student.Student_Email).FirstOrDefault();
            //IF STUDENT NOT EXISTS ADD NEW RECORD
            if(check==null)
            {
                db.Students.Add(student);
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
