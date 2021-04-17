using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H_API.Models;
namespace H_API.Models
{
    public class Eligibility
    {
        public int e_id { get; set; }
        public int s_id { get; set; }
        public int c_id { get; set; }
        public int level { get; set; }
    }
}