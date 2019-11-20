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

        public static bool IsExist(string isoCode)
        {
            IList<string> codes = GetCurrencyCodes();
            return codes.Any(x => x == isoCode);
        }
    }
}
