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

        public ActionResult Hemlig()
        {
            ViewData["secretGreet"] = "You found it!";

            return View();
        }

        public ActionResult Calculator()
        {
            Calculator calc = new Calculator();
            return View();
        }

        [HttpPost]
        public ActionResult Calculator(Calculator calc)
        {
            calc.VoltageResult = calc.Resistance * calc.Current;
            calc.ResistanceResult = calc.Voltage / calc.Current;
            calc.CurrentResult = calc.Voltage / calc.Resistance;
            Session["CalcSess"] = calc;

            return RedirectToAction("_ShowResult");
        }

        public ActionResult _ShowResult()
        {
            Calculator calc2 = (Calculator)Session["CalcSess"];
            return View(calc2);
        }
    }
}