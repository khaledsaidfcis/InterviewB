using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewB.Models;

namespace InterviewB.Controllers
{
    public class HomeController : Controller
    {
        private InterviewContext db = new InterviewContext();
        public ActionResult Index()
        {
            //Check if Session has a User
            // If not then , User is Null and required to login
            if (Session["user"] == null)
            {
                //Redirect to login page
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                return View();
            }
           
        }

       
        [HttpPost]
        public ActionResult GetAllData(FormCollection data)
        {
            //Get Form Parameters
            int _student_no = int.Parse(data["student_no"]);
            int _student_kind = int.Parse(data["student_kind"]);

            //Basic-Info
            var basic_info = db.BASIC_INFO.Where(b => b.STD_NO == _student_no
                                     && b.STD_KIND_CODE == _student_kind
                               ).FirstOrDefault();
          

            if(basic_info == null)
            {
                return Content("هذا الرقم غير صحيح");
            }

            //Medical-Info
            var medical_info = db.MEDICAL_INFO.Where(m => m.STD_NO == basic_info.STD_NO
                                        && m.STD_KIND_CODE == basic_info.STD_KIND_CODE
                                        ).FirstOrDefault();


            List<MEDICAL_DETAILS> medical_details = null;

            if (medical_info != null && medical_info.MEDICAL_STATUS_CODE != 1)
            {
                //Medical-Details
                medical_details = db.MEDICAL_DETAILS.Where(md => md.STD_NO == medical_info.STD_NO
                                                             && md.STD_KIND_CODE == medical_info.STD_KIND_CODE
                                                         ).ToList<MEDICAL_DETAILS>();
            }


            //Pass data to view
            ViewBag.basic_info = basic_info;
            ViewBag.medical_info = medical_info;
            ViewBag.medical_details = medical_details;

            return PartialView("_StudentCards");
        }

        public ActionResult Chat()
        {

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}