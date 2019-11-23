using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TechnicalAssignment.Utils
{
    public static class CurrencyUtils
    {
        public static IList<string> GetCurrencyCodes()
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures)
                              .Select(culture => culture.ThreeLetterISOLanguageName)
                              .Distinct()
                              .ToList();
        }

        public static IList<string> GetCurrencyList()
        {
            IList<string> CurrencyList = new List<string>();
            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (var culture in cultures)
            {
                /*
                 * We have to control here for the invariant culture (abbreviated as "ivl", basically the
                 * English language and associated with no single country/region) and neutral cultures
                 * (no country/region or defined number or date format). RegionInfo() will throw an
                 * ArgumentException for a neutral or invariant value.
                 */
                if (culture.ThreeLetterISOLanguageName == "ivl" || culture.IsNeutralCulture)
                {
                    continue;
                }
                else
                {
                    var cultureMoney = new RegionInfo(culture.Name);
                    CurrencyList.Add(cultureMoney.ISOCurrencySymbol);
                }
            }

            return CurrencyList;
        }
        public static bool IsExist(string isoCode)
        {
            IList<string> currencys = GetCurrencyList();
            return currencys.Any(currency => currency == isoCode);
        }
    }
}
