using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ExcelDataReader;
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

        [Route("api/questionbyexcel/")]
        [HttpPost]
        public string ExcelUpload()
        {
            string message = "";
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                HttpPostedFile file = httpRequest.Files[0];
                Stream stream = file.InputStream;
                IExcelDataReader reader = null;
                if (file.FileName.EndsWith(".xls"))
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (file.FileName.EndsWith(".xlsx"))
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                else
                {
                    message = "This file format is not supported";
                }
                DataSet excelRecords = reader.AsDataSet();
                reader.Close();
                string temp;
                var finalRecords = excelRecords.Tables[0];
                for (int i = 0; i < finalRecords.Rows.Count; i++)
                {
                    Question question = new Question();
                    question.Question1 = finalRecords.Rows[i][0].ToString();
                    question.Option1 = finalRecords.Rows[i][1].ToString();
                    question.Option2 = finalRecords.Rows[i][2].ToString();
                    question.Option3 = finalRecords.Rows[i][3].ToString();
                    question.Option4 = finalRecords.Rows[i][4].ToString();
                    question.Correct_ans = finalRecords.Rows[i][5].ToString();
                    question.e_id = Convert.ToDecimal(finalRecords.Rows[i][6]);

                    db.Questions.Add(question);
                }
                int output = db.SaveChanges();
                if (output > 0)
                {
                    message = "success";
                }
                else
                {
                    message = "Excel file uploaded has fiald";
                }
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return message;
        }


    }

}
