using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewB.Models
{
    public class USER
    {
        public int ID { get; set; }
        public string USERNAME { get; set; }
        public string NAME { get; set; }
        public string PASSWORD { get; set; }
        public int PRIORITY { get; set; }
        public int ISLOGGED { get; set; }
    }
}