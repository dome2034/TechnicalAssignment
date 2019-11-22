
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
            int expectFilesize = 1 * 1024 * 1024;
            if (postedFile != null && postedFile.ContentLength <= expectFilesize)
            {
                try
                {
                    string fileExtension = Path.GetExtension(postedFile.FileName);

                    if (fileExtension == ".csv")
                    {
                        var Transactions = new List<Transaction>();
                        using (var reader = new StreamReader(postedFile.InputStream))
                        using (var csv = new CsvReader(reader))
                        {
                            csv.Configuration.HasHeaderRecord = false;
                            while (csv.Read())
                            {
                                var record = new Transaction
                                {
                                    TransactionId = csv.GetField(0),
                                    Amount = double.Parse(Regex.Replace(csv.GetField(1), @"[^\d.]", "")),
                                    CurrencyCode = csv.GetField(2),
                                    Date = DateTime.ParseExact(csv.GetField(3), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture).Ticks,
                                    Status = (TransactionStatus) Enum.Parse(typeof(CSVTransactionStatus), csv.GetField(4), true)
                                };
                                Transactions.Add(record);
                            }
                            Transactions.ForEach(t=> InsertTransaction(t));
                        }
                    }
                    else if (fileExtension == ".xml")
                    {
                        var Transactions = new List<Transaction>();
                        var record = new Transaction();
                        XmlReader reader = XmlReader.Create(postedFile.InputStream);
                        while (reader.Read())
                        {
                            switch (reader.Name)
                            {
                                case "Transaction":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                    {
                                        Transactions.Add(record);
                                    }
                                    else
                                    {
                                        record.TransactionId = reader["id"];
                                    }
                                    break;
                                case "TransactionDate":
                                    string DateString = reader.ReadString();
                                    record.Date = DateTime.ParseExact(DateString, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal).Ticks;
                                    break;
                                case "PaymentDetails":
                                    break;
                                case "Amount":
                                    record.Amount = double.Parse(Regex.Replace(reader.ReadString(), @"[^\d.]", ""));
                                    break;
                                case "CurrencyCode":
                                    record.CurrencyCode = reader.ReadString();
                                    break;
                                case "Status":
                                    record.Status = (TransactionStatus)Enum.Parse(typeof(XMLTransactionStatus), reader.ReadString(), true);
                                    break;
                                default:
                                    break;
                            }
                        }
                        Transactions.ForEach(t => InsertTransaction(t));
                    }

                    //Validate uploaded file and return error.
                    else 
                    {
                        ViewBag.Message = "Please select the csv or xml file";
                        return View();
                    }
                    
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }
            }
            else
            {
                ViewBag.Message = "Please select the file first to upload.";
            }

            ViewBag.OkMessage = "Import File Complete!";
            return View();
        }

        [HttpPost]
         public ActionResult InsertTransaction(Transaction transaction)
        {
            using (var client = new HttpClient())
            {
                var rootUrl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
                client.BaseAddress = new Uri(rootUrl + "/api/transactions");

                //HTTP POST
                var postTask = client.PostAsJsonAsync("transactions", transaction).Result;

                var result = postTask;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(transaction);
        }
    }

}
