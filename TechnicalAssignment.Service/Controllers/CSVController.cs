
using TechnicalAssignment.Domain.Implementation;
using TechnicalAssignment.Domain.Enum;
using TechnicalAssignment.Utils;
using CsvHelper;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.IO;
using System;
using System.Globalization;


namespace TechnicalAssignment.Service.Controllers
{
    public class CSVController
    {
        public List<Transaction> TransactionExtract(HttpPostedFileBase postedFile)
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
                        Status = (TransactionStatus)Enum.Parse(typeof(CSVTransactionStatus), csv.GetField(4), true)
                    };
                    Transactions.Add(record);
                }
            }
            return Transactions;
        }
    }

}
