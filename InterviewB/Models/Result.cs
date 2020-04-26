using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterviewB.Models;

namespace InterviewB.Models
{
    public class Result
    {
        public MAIN_INFO main_info { get; set; }
        public List<MEDICAL_DETAILS>medical_details { get; set; }
        public List<RELATIVE> relatives_one { get; set; }
        public List<RELATIVE> relatives_two { get; set; }
        public List<RELATIVE> relatives_three { get; set; }
        public List<RELATIVE> relatives_four { get; set; }
        public NAFSI_INFO     nafsi_info { get; set; }
        public List<NAFSI_DETAILS>  nafsi_details { get; set; }
    }
}