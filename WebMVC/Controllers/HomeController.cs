using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
            var numberToText = new NumberToText();
            return View(numberToText);
        }


        [HttpPost]
        public ActionResult Index([Bind(Include = "FirstName,LastName,Amount")] NumberToText numberToText)
        {
            numberToText.ConvertAmountToWord(numberToText.Amount);
            return View(numberToText);
        }

    }
}