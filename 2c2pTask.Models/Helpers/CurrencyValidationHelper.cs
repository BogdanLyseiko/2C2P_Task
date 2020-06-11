using System.Globalization;

namespace _2c2pTask.Models.Helpers
{
    public static class CurrencyValidationHelper
    {
        private static CultureInfo cultureInfoFromCurrencyISO(string isoCode)
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo ci in cultures)
            {
                RegionInfo ri = new RegionInfo(ci.LCID);

                if (ri.ISOCurrencySymbol == isoCode)
                {
                    return ci;
                }
            }

            return null;
        }

        public static bool IsCurrencyNumberValid(string currencyNumber)
        {
            var cultureInfo = cultureInfoFromCurrencyISO(currencyNumber);

            if (cultureInfo == null)
            {
                return false;
            }

            return true;
        }
    }
}
