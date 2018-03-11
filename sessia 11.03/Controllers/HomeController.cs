using sessia_11._03.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace sessia_11._03.Controllers
{
    public class HomeController : Controller
    {
        
        public static List<User> login = new List<User>();
        public ActionResult Signup()
        {
            return View();
        }

       

        [HttpPost]
        public ActionResult Signup(User login)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\P502\Desktop\task\sessia 11.03\login.txt", append: true);
            sw.WriteLine(login.name + ";" + login.email + ";"+ login.pass + ";0");
            sw.Close();
            return View("Login");


        }


        public ActionResult Signin()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Signin(User signin)
        {
         
            StreamReader sr = new StreamReader(@"C:\Users\P502\Desktop\task\sessia 11.03\login.txt");
            while (sr.EndOfStream)
            {
                var thisLine = sr.ReadLine();
                var thisData = thisLine.Split(';');
                login.Add(new User()
                {
                    name=thisData[0],email=thisData[1],pass=thisData[2]
                });
                sr.Close();

            }
            //var usr = login.Find(f=>f.name,f=>f.)
            return View("MainPage");
        }

   
    }
}

