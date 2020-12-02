using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewB.Models
{
    public class BASIC_INFO
    {
        public int id { get; set; }
        public decimal STD_NO { get; set; }
        public decimal STD_KIND_CODE { get; set; }
        public string STD_KIND { get; set; }
        public string STD_NAME { get; set; }
        public string NATIONAL_ID { get; set; }
        public Nullable<System.DateTime> BIRTH_DATE { get; set; }
        public string CALCDATE { get; set; }
        public Nullable<short> PLACE_CODE { get; set; }
        public string PLACE { get; set; }
        public Nullable<decimal> SCN_CODE { get; set; }
        public string SCN { get; set; }
        public Nullable<decimal> SHOPA_CODE { get; set; }
        public string SHOPA { get; set; }
        public string SCN_NAME { get; set; }
        public Nullable<decimal> PERS { get; set; }
        public Nullable<decimal> COLLEGE_CODE { get; set; }
        public string COLLEGE { get; set; }
        public Nullable<decimal> GRADUATION_CODE { get; set; }
        public string GRADUATION { get; set; }
        public Nullable<decimal> POST_GRADUATION_CODE { get; set; }
        public string POST_GRADUATION { get; set; }
        public Nullable<decimal> GRADE_CODE { get; set; }
        public string GRADE { get; set; }
    }
}