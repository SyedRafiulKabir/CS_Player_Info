using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS_Player_Info_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult AddPlayer()
        {
            return View();
        }

        // Action to render PlayerList view
        public ActionResult PlayerList()
        {
            return View();
        }

        // Optional: Action to render EditPlayer view
        public ActionResult Edit(int id)
        {
            ViewBag.PlayerId = id;
            return View("EditPlayer");
        }
    }
}
