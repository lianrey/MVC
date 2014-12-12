using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCExample.DAL;
using MVCExample.Models;
using System.Web.Security;

namespace MVCExample.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Authenticate()
        {
            return View("Login");
        }

        public ActionResult Validate()
        {

            string username = Request.Form["UserName"].Trim();
            string password = Request.Form["Password"].Trim();

            Dal dal = new Dal();
            List<User> users = (from u in dal.Users
                                where (u.UserName == username)
                                 && (u.Password == password)
                                select u).ToList<User>();

            if (users.Count == 1)
            {
                FormsAuthentication.SetAuthCookie("Cookie", true);
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                return View("Login");
            }
        }

    }
}
