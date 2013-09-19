using ChecklistApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChecklistApplication.Controllers
{
    public class HomeController : Controller
    {
       // private ChecklistDBContext db = new ChecklistDBContext();
        public ActionResult Index()
        {
            //db.Checklists.Find(1);
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
