using TechnicalAssignment.Domain.Implementation;
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
    public class XMLImportTest
    {

        [TestInitialize]
        public void Initialize()
        {
            // skeleton
        }

        [TestMethod]
        public void can_import_data()
        {
            string filePath = Path.GetFullPath(@"Service\FileTest\Test.xml");
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            Mock<HttpPostedFileBase> uploadedFile = new Mock<HttpPostedFileBase>();
            XMLController csvTest = new XMLController();

            uploadedFile.Setup(f => f.InputStream).Returns(fileStream);
            var actual = csvTest.TransactionExtract(uploadedFile.Object);

            NUnit.Framework.Assert.That(actual, Is.TypeOf<List<Transaction>>());

            fileStream.Close();
        }
    }
}
