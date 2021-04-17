﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using H_API.Models;

namespace H_API.Controllers
{
    public class ResultsController : ApiController
    {
        //CREATE ENTITIY OBJECT
        Online_examEntities db = new Online_examEntities();
        [Route("api/Results/CheckEligible")]
        [HttpPost]
        public IHttpActionResult post(Eligibility eligibility)
        {
            if(eligibility.level==1)
            {
                return Ok("valid");
            }
            var results = db.ViewAll_Results_ByExam().ToList();
            int exam_id = 0;
            int found = 0;
            //FIND THE EXAM ID OF THE PREVIOUS LEVEL
            foreach (var i in results)
            {
                
               if(i.Course_id== eligibility.c_id && i.level==eligibility.level-1)
                {
                     exam_id =  (int) i.e_id;
                    break;
                }
            }
            foreach(var i in results)
            {
                if(i.s_id==eligibility.s_id && i.e_id== exam_id)
                {
                    found = 1;
                    break;
                }
            }
            if(found==1)
            {
                return Ok("valid");
            }
            else
            {
                return Ok("error");
            }
        }



        [Route("api/Results/GetResults")]
        [HttpPost]
        public IHttpActionResult Post( Answers[] answers)
        {
            var questions = db.View_Questions_ByExam(answers[0].e_id);
            float score=0;
            int index = 0;
            int no_of_questions=0;
           foreach(var i in questions)
            {
                if(i.Correct_ans==answers[index].answerSelected)    
                {
                    score += 1;
                }
                index += 1;
                no_of_questions += 1;
            }
            score = (score / no_of_questions) * 100;
            db.Results.Add(new Result()
            {
                Result1 = score.ToString(),
                s_id= answers[0].s_id,
                e_id= answers[0].e_id
            }) ;
            db.SaveChanges();
            return Ok(score);
        }
    }
}