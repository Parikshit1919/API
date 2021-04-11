using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using H_API.Models;
namespace H_API.Controllers
{
    public class AdminLoginController : ApiController
    {
        //CREATE ENTITIY OBJECT
        Online_examEntities db = new Online_examEntities();

        [HttpPost]
        public IHttpActionResult Post(Admin admin)
        {
            var check = db.Admins.Where(a => a.Admin_Email == admin.Admin_Email && a.Admin_Password == admin.Admin_Password).FirstOrDefault();
            if (check!=null)
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
