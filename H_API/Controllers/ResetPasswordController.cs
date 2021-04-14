using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.UI;
using H_API.Models;

namespace H_API.Controllers
{
    public class ResetPasswordController : ApiController
    {
        //CREATE ENTITIY OBJECT
        Online_examEntities db = new Online_examEntities();

        //METHOD TO EMAIL RESET KEY 
        [HttpGet]
        public IHttpActionResult Get(string email)
        {
            var check = db.Students.Where(a => a.Student_Email == email).FirstOrDefault();
            //CHECK FOR ANY PREVIOUS RESETS
            var check_reset = db.Forgot_Pass.Where(a => a.s_email == email).FirstOrDefault();
            //REMOVE THEM IF NEEDED
            if(check_reset!=null)
            {
                db.Forgot_Pass.Remove(check_reset);
                db.SaveChanges();
            }
            System.Random random = new System.Random();
            if (check!=null)
            {
                //GENERATE RANDOM AND SAVE IN DB
                int reset_key = random.Next(1000);
                db.Forgot_Pass.Add(new Forgot_Pass()
                {
                    s_id = check.Student_id,
                    s_email = check.Student_Email,
                    reset_key = reset_key.ToString()
                }
                );
                db.SaveChanges();

                //SEND EMAIL
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.To.Add(email); //SEND EMAIL TO
                mail.From = new MailAddress("hackathonwebbot@gmail.com", "NoReply@Hacathon", System.Text.Encoding.UTF8);
                mail.Subject = "Hackathon Reset Password";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = "YOUR RESET KEY IS "+reset_key;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("hackathonwebbot@gmail.com", "ABC@#123");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                try
                {
                    client.Send(mail);
                   
                }
                catch (Exception ex)
                {
                    Exception ex2 = ex;
                    string errorMessage = string.Empty;
                    while (ex2 != null)
                    {
                        errorMessage += ex2.ToString();
                        ex2 = ex2.InnerException;
                    }
         
                }

                return Ok("sent");
            }
            else
            {
                return Ok("error");
            }
        }

        [HttpPost]
        public IHttpActionResult Post(PasswordReset password)
        {
            var check = db.Forgot_Pass.Where(a => a.s_email == password.Email && a.reset_key == password.resetcode).FirstOrDefault();
            if(check!=null)
            {
                var student = db.Students.Find(check.s_id);
                student.Student_Password = password.newpassword;
                db.Forgot_Pass.Remove(check);
                db.SaveChanges();
                return Ok("changed");
            }
            else
            {
                return Ok("error");
            }

        }
    }
}
