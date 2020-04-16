using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewB.Models;

namespace InterviewB.Controllers
{
    public class AuthController : Controller
    {
        //Iniliaze DB
        //private InterviewContext db = new InterviewContext();
        private InterviewContext db = DBClass.GetConnection();

        [HttpGet]
        public ActionResult Login()
        {
            if (TempData["FailedLogin"] != null) ViewBag.FailedLogin = TempData["FailedLogin"];
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            //Get Form Parameters
            string _user = form["user"].ToLower();
            string _password = form["password"].ToLower();

            //Make DB Checking to Match User

            var User = db.USERS.Where(u => u.USERNAME.ToLower() == _user
                                     && u.PASSWORD.ToLower() == _password
                                   ).FirstOrDefault();
            
            // Null User , Failed to login 
            if (User == null)
            {
                TempData["FailedLogin"] = "الاسم أو رقم السر غير صحيح";
                return RedirectToAction("Login", "Auth");
            }
            //If True then redirect to Home/Index
            //Store User IN Session 
            Session["user"] = User;

            //db.Dispose();
            DBClass.disconnect();

            return RedirectToAction("Index", "Home");
            
        }

        [HttpGet]
        public ActionResult Logout()
        {
            //Logout from DB
            var user = (USER)Session["user"];

            user = db.USERS
                    .Where(u => u.USERNAME == user.USERNAME)
                    .FirstOrDefault();

            user.CONNECTIONID = null;
            db.SaveChanges();

            //Remove From Session
            Session["user"] = null;
            //Redirect To LoginPage
            return RedirectToAction("Login", "Auth");
        }
    }
}