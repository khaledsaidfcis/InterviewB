using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InterviewB.Models
{
    public class Student
    {
        public int ID { get; set; }
        public int StudentID { get; set; }

        public double? NationalID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Qualification { get; set; }
        //public int Grade { get; set; }
        //public string Center { get; set; }
        //public string Governorate { get; set; }
        //public string Address { get; set; }
        public string Job { get; set; }
        public string Area { get; set; }
        public string Governorate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        //public string FatherJob { get; set; }
        [DefaultValue(2)]
        public int Type { get; set;} 
        public DateTime AttendanceDay { get; set; }
        public double Fitness { get; set; }
        public string Psychological { get; set; }

        [DefaultValue(-1)]
        public double GeneralLook { get; set; }
        [DefaultValue(-1)]
        public double GeneralLook2 { get; set; }
        [DefaultValue(-1)]
        public double GeneralLook3 { get; set; }
        [DefaultValue(-1)]
        public double GeneralLook4 { get; set; }
        [DefaultValue(-1)]
        public double GeneralLook5 { get; set; }
        [DefaultValue(-1)]
        public double GeneralLook6 { get; set; }

        [DefaultValue(-1)]
        public double CulturalLevel { get; set; }
        [DefaultValue(-1)]
        public double CulturalLevel2 { get; set; }
        [DefaultValue(-1)]
        public double CulturalLevel3 { get; set; }
        [DefaultValue(-1)]
        public double CulturalLevel4 { get; set; }
        [DefaultValue(-1)]
        public double CulturalLevel5 { get; set; }
        [DefaultValue(-1)]
        public double CulturalLevel6 { get; set; }

        [DefaultValue(-1)]
        public double TrainingStaffOpinion { get; set; }
        [DefaultValue(-1)]
        public double TrainingStaffOpinion2 { get; set; }
        [DefaultValue(-1)]
        public double TrainingStaffOpinion3 { get; set; }
        [DefaultValue(-1)]
        public double TrainingStaffOpinion4 { get; set; }
        [DefaultValue(-1)]
        public double TrainingStaffOpinion5 { get; set; }
        [DefaultValue(-1)]
        public double TrainingStaffOpinion6 { get; set; }
        [DefaultValue(-1)]
        public double TransportationOpinion { get; set; }
        
       
        
    }
}