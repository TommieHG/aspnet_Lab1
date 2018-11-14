using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab1.Models;

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
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {

            if (Session["Username"] != null)
            {
                ViewBag.Username = "This page is not about you " + Session["Username"] + "!";
            }
            else
            {
                ViewBag.Username = "This page is about stuff";
            }

            ViewBag.ferg = Session["color"];
            return View();
        }

        [HttpPost]
        public ActionResult About(FormCollection title_Color)
        {
            Session["color"] = title_Color["color"].ToString();

            return RedirectToAction("About");
        }

        public ActionResult Hemlig()
        {
            ViewData["secretGreet"] = "You found it!";

            return View();
        }

        [HttpPost]
        public ActionResult Hemlig(FormCollection delete_Collect)
        {
            if (delete_Collect["boxcheck"] == "1")
            {
                Session.Remove("Username");
            }
            
            return RedirectToAction("Hemlig");
        }

        public ActionResult Calculator()
        {
            //object declared only for values 0 to be put i form fields
            Calculator cal = new Calculator();
            cal.Current = 0;
            cal.Voltage = 0;
            cal.Resistance = 0;

            return View(cal);
        }

        [HttpPost]
        public ActionResult Calculator(Calculator cal)
        {

            cal.VoltageResult = cal.Current * cal.Resistance;
            cal.ResistanceResult = cal.Voltage / cal.Current;
            cal.CurrentResult = cal.Voltage / cal.Resistance;

            return View(cal);
        }
    }
}