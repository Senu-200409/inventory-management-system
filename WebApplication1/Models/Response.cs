using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DataAccess;

namespace WebApplication1.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string Result { get; set; }
        public object  ResultSet { get; set; }
    }
}