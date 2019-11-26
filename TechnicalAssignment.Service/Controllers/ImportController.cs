
using TechnicalAssignment.BusinessLogic.Interface;
using TechnicalAssignment.Domain.Implementation;
using TechnicalAssignment.Domain.Enum;
using TechnicalAssignment.Utils;
using CsvHelper;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System;
using System.Globalization;
using System.Xml;
using TechnicalAssignment.Domain.Interface;
using WebErrorLogging.Utilities;

namespace TechnicalAssignment.Service.Controllers
{
    public class ImportController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Upload Page";

            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            CSVController CSV = new CSVController();
            XMLController XML = new XMLController();
            int expectFilesize = 1 * 1024 * 1024;
            if (postedFile != null && postedFile.ContentLength <= expectFilesize)
            {
                try
                {
                    string fileExtension = Path.GetExtension(postedFile.FileName);

                    if (fileExtension == ".csv")
                    {
                        var Transactions = CSV.TransactionExtract(postedFile);
                        Transactions.ForEach(t=> InsertTransaction(t));
                    }
                    else if (fileExtension == ".xml")
                    {
                        var Transactions = XML.TransactionExtract(postedFile);
                        Transactions.ForEach(t => InsertTransaction(t));
                    }

                    //Validate uploaded file and return error.
                    else 
                    {
                        ViewBag.ErrorMessage = "Please select the csv or xml file";
                        Helper.WriteWarning(null, ViewBag.ErrorMessage);
                        return View();
                    }
                    ViewBag.OkMessage = "Import File Complete!";
                }
                catch (Exception ex)
                {
                    Helper.WriteError(ex, "Error");
                    ViewBag.ErrorMessage = ex.Message;
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Please select the file first to upload.";
                Helper.WriteWarning(null, ViewBag.ErrorMessage);
            }

            return View();
        }

        [HttpPost]
         public ActionResult InsertTransaction(Transaction transaction)
        {
            try
            {
                var client = new HttpClient();
                var rootUrl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
                client.BaseAddress = new Uri(rootUrl + "/api/transactions");

                //HTTP POST
                var postTask = client.PostAsJsonAsync("transactions", transaction).Result;
                var result = postTask;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return View();
            }
            catch (Exception ex)
            {
                Helper.WriteError(ex, "Error");
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
            
        }
    }

}
