using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using H_API.Models;
namespace H_API.Controllers
{
    public class AdminExamResultController : ApiController
    {
        //CREATE ENTITIY OBJECT
        Online_examEntities db = new Online_examEntities();


        //METHOD To GET RESULT BT EXAM ID
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var results = db.View_Results_ByExam(id).ToList();
            int size = results.Count();
            if(size>0)
            {
                return Ok(results);
            }
            else
            {
                return Ok("not_found");
            }
         
        }

        //METHOD TO GET ALL RESULTS
        [HttpGet]
        [Route("api/AdminExamResult/ViewAll")]
        public IHttpActionResult Get()
        {
            var results = db.ViewAll_Results_ByExam(); //CALLING STORED PROCEDURE
            return Ok(results);

        }

        //METHOD TO GET RESULTS BY STUDENT ID
        [HttpGet]
        [Route("api/AdminExamResult/ByStudent")]
        public IHttpActionResult get_by_student_ID(int id)
        {
            var results = db.View_Results_ByStudent(id);
            return Ok(results);

        }

        //METHOD TO GET RESUTLS BY STUDENT EMAIL
        [HttpGet]
        [Route("api/AdminExamResult/ByEmail")]
        public IHttpActionResult get_by_student_Email(string email)
        {
            var results = db.View_Results_ByEmail(email);
            return Ok(results);

        }
    }
}
