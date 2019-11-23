using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebErrorLogging.Utilities;

namespace TechnicalAssignment.Service.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                Helper.WriteDebug(null, "Debug ");
                ViewBag.Title = "Home Page";
                return View();
            }
            catch (Exception ex)
            {
                Helper.WriteError(ex, "Error");
                Helper.WriteFatal(ex, "Fatal");
                Helper.WriteVerbose(ex, "Verbose");
                throw;
            }

        }
    }
}
