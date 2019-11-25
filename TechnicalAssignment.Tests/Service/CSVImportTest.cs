using TechnicalAssignment.Domain.Implementation;
using WebErrorLogging.Utilities;
using TechnicalAssignment.Domain.Enum;
using TechnicalAssignment.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.IO;
using Moq;
using NUnit.Framework;
using System.Web;
using System.Collections.Generic;

namespace TechnicalAssignment.Service.Controllers
{
    [TestClass, TestCategory("unittest")]
    public class CSVImportTest
    {

        [TestInitialize]
        public void Initialize()
        {
            // skeleton
        }

        [TestMethod]
        public void can_import_data()
        {
            FileStream fileStream = new FileStream(Path.GetFullPath(@"Service\FileTest\Test.csv"), FileMode.Open);
            FileStream fileStream_AmountFailed = new FileStream(Path.GetFullPath(@"Service\FileTest\TestAmountFailed.csv"), FileMode.Open);
            FileStream fileStream_CurrencyFailed = new FileStream(Path.GetFullPath(@"Service\FileTest\TestCurrencyFailed.csv"), FileMode.Open);
            FileStream fileStream_DateFailed = new FileStream(Path.GetFullPath(@"Service\FileTest\TestDateFailed.csv"), FileMode.Open);
            FileStream fileStream_StatusFailed = new FileStream(Path.GetFullPath(@"Service\FileTest\TestStatusFailed.csv"), FileMode.Open);
            Mock<HttpPostedFileBase> uploadedFile = new Mock<HttpPostedFileBase>();
            CSVController csvTest = new CSVController();

            // Test Pass
            uploadedFile.Setup(f => f.InputStream).Returns(fileStream);
            NUnit.Framework.Assert.That(csvTest.TransactionExtract(uploadedFile.Object), Is.TypeOf<List<Transaction>>());
            fileStream.Close();

            // Test Amount failed
            uploadedFile.Setup(f => f.InputStream).Returns(fileStream_AmountFailed);
            NUnit.Framework.Assert.That(() => csvTest.TransactionExtract(uploadedFile.Object), Throws.Exception);
            fileStream_AmountFailed.Close();

            // Test Currency failed
            uploadedFile.Setup(f => f.InputStream).Returns(fileStream_CurrencyFailed);
            NUnit.Framework.Assert.That(() => csvTest.TransactionExtract(uploadedFile.Object), Throws.Exception);
            fileStream_CurrencyFailed.Close();

            // Test Date failed
            uploadedFile.Setup(f => f.InputStream).Returns(fileStream_DateFailed);
            NUnit.Framework.Assert.That(() => csvTest.TransactionExtract(uploadedFile.Object), Throws.Exception);
            fileStream_DateFailed.Close();

            // Test Status failed
            uploadedFile.Setup(f => f.InputStream).Returns(fileStream_StatusFailed);
            NUnit.Framework.Assert.That(() => csvTest.TransactionExtract(uploadedFile.Object), Throws.Exception);
            fileStream_StatusFailed.Close();
        }
    }
}
