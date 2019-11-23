
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
using System.Xml;
using WebErrorLogging.Utilities;


namespace TechnicalAssignment.Service.Controllers
{
    public class XMLController
    {
        public List<Transaction> TransactionExtract(HttpPostedFileBase postedFile)
        {
            try
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
                            record.CurrencyCode = CurrencyUtils.IsExist(reader.ReadString()) ? reader.ReadString() : throw new ArgumentException(reader.ReadString().ToString()+" is not Currency!!");
                            break;
                        case "Status":
                            record.Status = (TransactionStatus)Enum.Parse(typeof(XMLTransactionStatus), reader.ReadString(), true);
                            break;
                        default:
                            break;
                    }
                }
                return Transactions;
            }
            catch (Exception ex)
            {
                Helper.WriteError(ex, "Error");
                throw;
            }
            
        }
    }

}
