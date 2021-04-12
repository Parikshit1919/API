using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using H_API.Models;

namespace H_API.Controllers
{
    public class LoginController : ApiController
    {
        //CREATE ENTITIY OBJECT
        Online_examEntities1 db = new Online_examEntities1();

        //METHOD TO CHECK FOR STUDENT LOGIN CREDENTIALS
        [HttpPost]
        public IHttpActionResult Post(Student student)
        {
            //CHECK IF STUDENT RECORDS EXIST
            var check = db.Students.Where(a => a.Student_Email == student.Student_Email && a.Student_Password == student.Student_Password).FirstOrDefault();
            if(check!=null)
            {
                return Ok("valid");
            }
            else 
            {
                return Ok("invalid");
            }
        }
    }
}
