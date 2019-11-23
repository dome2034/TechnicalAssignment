using TechnicalAssignment.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TechnicalAssignment.Utils
{
    [TestClass, TestCategory("unittest")]
    public class UtilesTest
    {

        [TestInitialize]
        public void Initialize()
        {
            // skeleton
        }

        [TestMethod]
        public void can_convert_to_timestamp()
        {
            DateTime testingDateTime = new DateTime(1970, 10, 1, 0, 0, 0);
            long timestamp = testingDateTime.ToUnixTimestamp();

            Assert.AreEqual(23587200, timestamp);
        }

        [TestMethod]
        public void can_convert_string_to_timestamp()
        {
            long timestamp = "03/09/2019 14:09".ToUnixTimestamp();

            Assert.AreEqual(1567519200, timestamp);
        }

        [TestMethod]
        public void can_convert_from_timestamp()
        {
            DateTime testingDateTime = new DateTime(1970, 1, 1, 0, 0, 0);
            long timestamp = testingDateTime.ToUnixTimestamp();

            Assert.AreEqual(0, timestamp);
        }

        [TestMethod]
        public void can_get_currency_codes()
        {
            Assert.IsTrue(CurrencyUtils.GetCurrencyCodes().Any());
            Assert.IsTrue(CurrencyUtils.IsExist("USD"));
            Assert.IsFalse(CurrencyUtils.IsExist("SOME_RANDOM"));
        }
    }
}
