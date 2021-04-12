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
        Online_examEntities1 db = new Online_examEntities1();

        //METHOD TO GET ALL COURSES IN THE COURSES TABLE
        [HttpGet]
        public IHttpActionResult Get()
        {
            var courses = db.VIEW_COURSES(); //CALLING STORED PROCEDURE
            return Ok(courses);
        }

        //METHOD TO ADD NEW COURSES
        [HttpPost]
        public IHttpActionResult Post(Cours course)
        {
            var check = db.Courses.Where(a => a.Course_name == course.Course_name).FirstOrDefault();
            //CHECK IF COURSE IS ALREADY ADDED
            if(check==null)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return Ok("added");
            }
            //RETURN EXISITS IF IT AREADY EXISTS
            else 
            {
                return Ok("exists");
            }
        }

        //METHOD TO DELETE COURSES
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            //FIND THE REQUESTED COURSE
            var course = db.Courses.Find(id);
            //DELTE IF IT EXISTS
            if (course!=null)
            {
                db.Courses.Remove(course);
                db.SaveChanges();
                return Ok("removed");
            }
            //ELSE RETURN ERROR
            else
            {
                return Ok("not_found");
            }
        }
    }
}
