using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H_API.Models
{
    public class PasswordReset
    {
       public string Email { get; set; }
       public string confirmpassword { get; set; }
       public string newpassword { get; set; }
       public string resetcode { get; set; }
    }
}