using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection name_Collect)
        {
            Session["Username"] = name_Collect["nameText"].ToString();
            ViewBag.welcomeMessage = "Hello there " + name_Collect["nameText"].ToString() + "!";
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "What's this all about?";

            if(Session["Username"] != null)
            {
                ViewBag.Username = "This page is not about you " + Session["Username"] + "!";
            }
            else
            {
                ViewBag.Username = "This page is about stuff";
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Hemlig()
        {
            ViewBag.Message = "You found it!";

            return View();
        }
    }
}