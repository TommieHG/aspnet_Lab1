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
            //Calculator calc = new Calculator();
            return View();
        }

        //[HttpPost]
        //public ActionResult Calculator(Calculator calc)
        //{
        //    calc.VoltageResult = calc.Resistance * calc.Current;
        //    calc.ResistanceResult = calc.Voltage / calc.Current;
        //    calc.CurrentResult = calc.Voltage / calc.Resistance;
        //    Session["CalcSess"] = calc;
            

        //    return RedirectToAction("_ShowResult");
        //}

        [HttpPost]
        public ActionResult Calculator(FormCollection calc_Collection)
        {
            Calculator cal = new Calculator();

            cal.Current = Convert.ToDouble(calc_Collection["Current"]);
            cal.Resistance = Convert.ToDouble(calc_Collection["Resistance"]);
            cal.Voltage = Convert.ToDouble(calc_Collection["Voltage"]);

            cal.VoltageResult = cal.Current * cal.Resistance;
            cal.ResistanceResult = cal.Voltage / cal.Current;
            cal.CurrentResult = cal.Voltage / cal.Resistance;

            Session["voltage"] = cal.VoltageResult;
            Session["resistance"] = cal.ResistanceResult;
            Session["current"] = cal.CurrentResult;

            return RedirectToAction("Calculator");
        }

    }
}