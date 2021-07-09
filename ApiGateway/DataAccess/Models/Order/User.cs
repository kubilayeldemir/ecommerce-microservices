using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models.Order
{
    public class User
    {
        public long id { get; set; }
        public String name { get; set; }
        public String eMail { get; set; }
        public String address { get; set; }
        public String phoneNumber { get; set; }
    }
}
