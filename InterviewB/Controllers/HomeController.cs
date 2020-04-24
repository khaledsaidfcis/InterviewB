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
        //private InterviewContext db = new InterviewContext();

        private InterviewContext db = DBClass.GetConnection();
        

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


            //Querry To Get Basic_info  & Parents_info & Medical_info & Sports_info
            var main_info = db.MAIN_INFO.Where(mi => mi.STD_NO == _student_no
                                           && mi.STD_KIND_CODE == _student_kind)
                                            .FirstOrDefault();
            if( main_info == null)
            {
                //TODO: Make It Error View
                return Content("هذا الرقم غير صحيح");
            }

            /*
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
                                        && m.STD_KIND_CODE == basic_info.STD_KIND_CODE)
                                        .FirstOrDefault();
            */

            List<MEDICAL_DETAILS> medical_details = null;

            if (main_info != null && main_info.MEDICAL_STATUS_CODE != 1)
            {
                //Medical-Details
                medical_details = db.MEDICAL_DETAILS.Where(md => md.STD_NO == _student_no
                                                      && md.STD_KIND_CODE == _student_kind)
                                                       .ToList();
            }

            /*
            //Sport-Info
            var sport_info = db.SPORT_INFO.Where(sp => sp.STD_NO == medical_info.STD_NO
                                                     && sp.STD_KIND_CODE == medical_info.STD_KIND_CODE)
                                                     .FirstOrDefault();

            //Parents-Info
            var parents_info = db.PARENTS_INFO.Where(p => p.STD_NO == sport_info.STD_NO
                                                   && p.STD_KIND_CODE == sport_info.STD_KIND_CODE)
                                                    .FirstOrDefault();
            */


            //RELATIVES
            var relatives = db.RELATIVES.Where(rel => rel.STD_NO == _student_no
                                          && rel.STD_KIND_CODE == _student_kind)
                                           .ToList();

            var relatives_one = relatives.Where(rel => rel.RELATION == 1).ToList();
            var relatives_two = relatives.Where(rel => rel.RELATION == 2).ToList();
            var relatives_three = relatives.Where(rel => rel.RELATION == 3).ToList();
            var relatives_four = relatives.Where(rel => rel.RELATION == 4).ToList();

            /*
            var relatives_one = db.RELATIVES_ONE.Where(rel => rel.STD_NO == basic_info.STD_NO
                                                  && rel.STD_KIND_CODE == basic_info.STD_KIND_CODE)
                                                   .OrderBy(r => r.SERIAL)
                                                    .ToList();
           
            var relatives_two = db.RELATIVES_TWO.Where(rel => rel.STD_NO == basic_info.STD_NO
                                                  && rel.STD_KIND_CODE == basic_info.STD_KIND_CODE)
                                                   .OrderBy(r => r.SERIAL)
                                                    .ToList();

            var relatives_three = db.RELATIVES_THREE.Where(rel => rel.STD_NO == basic_info.STD_NO
                                                  && rel.STD_KIND_CODE == basic_info.STD_KIND_CODE)
                                                   .OrderBy(r => r.SERIAL)
                                                    .ToList();

            var relatives_four = db.RELATIVES_FOUR.Where(rel => rel.STD_NO == basic_info.STD_NO
                                                  && rel.STD_KIND_CODE == basic_info.STD_KIND_CODE)
                                                   .OrderBy(r => r.SERIAL)
                                                    .ToList();
            */
            //Nafsi-Info
            var nafsi_info = db.NAFSI_INFO.Where(n => n.STD_NO == _student_no
                                           && n.STD_KIND_CODE == _student_kind)
                                             .FirstOrDefault();
            //Nafsi-Details
            var nafsi_details = db.NAFSI_DETAILS.Where(nd => nd.STD_NO == _student_no
                                                 && nd.STD_KIND_CODE == _student_kind)
                                                 .ToList();

            //Pass data to view
            ViewBag.main_info = main_info;
            //ViewBag.basic_info      = basic_info;
            //ViewBag.medical_info    = medical_info;
            ViewBag.medical_details = medical_details;
            //ViewBag.sport_info      = sport_info;
            //ViewBag.parents_info    = parents_info;
            ViewBag.relatives_one   = relatives_one;
            ViewBag.relatives_two   = relatives_two;
            ViewBag.relatives_three = relatives_three;
            ViewBag.relatives_four  = relatives_four;
            ViewBag.nafsi_info      = nafsi_info;
            ViewBag.nafsi_details   = nafsi_details;
            ViewBag.relatives       = relatives;


            // db.Dispose();
            //DBClass.disconnect();

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