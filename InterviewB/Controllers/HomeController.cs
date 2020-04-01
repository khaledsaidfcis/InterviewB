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
            //Pass it to view
            ViewBag.basic_info = basic_info;


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