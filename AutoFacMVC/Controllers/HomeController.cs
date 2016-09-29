using AutoFacMVC.IServices;
using AutoFacMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoFacMVC.Controllers
{
    public class HomeController : Controller
    {
        private ITestService _testServices;

        public HomeController(ITestService testServices)
        {
            _testServices = testServices;
        }
        public ActionResult Index()
        {
            var Names=_testServices.GetNames();
            ViewBag.info = Names;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}