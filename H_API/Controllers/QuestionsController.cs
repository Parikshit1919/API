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
    public class QuestionsController : ApiController
    {
        //CREATE ENTITIY OBJECT
        Online_examEntities db = new Online_examEntities();

        //METHOD TO ADD QUESTIONS
        [HttpPost]
        public IHttpActionResult Post(Question question)
        {
            try
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return Ok("added");
            }
            catch (Exception e)
            {
                return Ok("error");
            }
        }

        //METHOD TO GET QUESTIONS BY EXAM
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var questions = db.View_Questions_ByExam(id);
            if (questions!=null)
            {
                return Ok(questions);
            }
            else

            {
                return Ok("error");
            }
        }


        //METHOD TO GET QUESTIONS BY QUESION ID
        [Route("api/Questions/ByQuestionID/")]
        [HttpGet]
        public IHttpActionResult get(int id)
        {
            var question = db.View_Questions_ByID(id).FirstOrDefault();
            if (question != null)
            {
                return Ok(question);
            }
            else

            {
                return Ok("error");
            }
        }
        //METHOD TO DELETE A QUESTION
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var question = db.Questions.Find(id);
            try
            {
                db.Questions.Remove(question);
                db.SaveChanges();
                return Ok("removed");
            }
            catch(Exception e)
            {
                return Ok("error");
            }
        }

        //METHOD TO CHANGE QUESITON
        [HttpPut]
        public IHttpActionResult Put(Question question)
        {
            try
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return Ok("changed");
            }
            catch (Exception e)
            {
                return Ok("error");
            }
        }
    }
    
}
