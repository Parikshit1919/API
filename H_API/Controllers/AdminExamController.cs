using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using H_API.Models;

namespace H_API.Controllers
{
    public class AdminExamController : ApiController
    {
        //CREATE ENTITIY OBJECT
        Online_examEntities db = new Online_examEntities();

        //METHOD TO GET ALL EXAMS
        [HttpGet]
        public IHttpActionResult Get()
        {
            var exams = db.View_Exams();
            return Ok(exams);
        }

        //METHOD TO ADD EXAMS
        [HttpPost]
        public IHttpActionResult Post(Exam exam)
        {
            try
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return Ok("added");
            }
            catch (Exception e) 
            {
                return Ok("error");
            }
            
        }

        //METHOD TO GET EXAM BY ID
        [Route("api/ExamsByID")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(db.View_Exams_BYID(id).FirstOrDefault());
        }
         
        
        //METHOD TO MODIFY EXAM
        [HttpPut]
        public IHttpActionResult Put(Exam exam)
        {
            try
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return Ok("changed");
            }
            catch (Exception e)
            {
                return Ok("error");
            }
        }
    


        //METHOD TO DELETE EXAMS
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var exam = db.Exams.Find(id);
            if (exam != null)
            {
                db.Exams.Remove(exam);
                db.SaveChanges();
                return Ok("removed");
            }
            else
            {
                return Ok("exam_error");
            }
        }
    }
}
