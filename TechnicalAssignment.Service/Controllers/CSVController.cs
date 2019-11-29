
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
using WebErrorLogging.Utilities;

namespace TechnicalAssignment.Service.Controllers
{
    public class CSVController
    {
        public List<Transaction> TransactionExtract(HttpPostedFileBase postedFile)
        {
            try
            {
                var Transactions = new List<Transaction>();
                var reader = new StreamReader(postedFile.InputStream);
                var csv = new CsvReader(reader);
                csv.Configuration.HasHeaderRecord = false;
                while (csv.Read())
                {
                    var record = new Transaction
                    {
                        TransactionId = csv.GetField(0),
                        Amount = double.Parse(Regex.Replace(csv.GetField(1), @"[^\d.]", "")),
                        CurrencyCode = CurrencyUtils.IsExist(csv.GetField(2)) ? csv.GetField(2) : throw new ArgumentException(csv.GetField(2).ToString()+" is not Currency!!"),
                        Date = DateTime.ParseExact(csv.GetField(3), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture).Ticks,
                        Status = (TransactionStatus)Enum.Parse(typeof(CSVTransactionStatus), csv.GetField(4), true)
                    };
                    Transactions.Add(record);
                }
                return Transactions;
            }
            catch (Exception ex)
            {
                Helper.WriteError(ex, "Error");
                throw ex;
            }
                
        }
    }

}
