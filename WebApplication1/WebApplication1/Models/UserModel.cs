﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
     
        public string Amount { get; set; }
        public string PhoneNo { get; set; }
        public string Date { get; set; }

    }
}