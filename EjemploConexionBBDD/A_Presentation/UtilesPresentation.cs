using System;
using System.Globalization;

namespace esqueletoProgramaCRUDconBD.A_Presentation
{
    public static class UtilesPresentation
    {
        public static void AskUserForData(string dataName)
        {
            Console.Write($"{dataName}: ");
        }

        public static string GetStringFromUser(string dataName)
        {
            AskUserForData(dataName);
            return Console.ReadLine();
        }

        public static int? GetIntFromUser(string dataName)
        {
            int? resul = null;
            AskUserForData(dataName);
            if(int.TryParse(Console.ReadLine(), out int goodInt) == true)
            {
                resul = goodInt;
            }
            return resul;
        }

        public static decimal? GetDecimalFromUser(string dataName)
        {
            decimal? resul = null;
            AskUserForData(dataName);
            if (decimal.TryParse(Console.ReadLine().Replace('.',','), out decimal goodDecimal) == true)
            {
                resul = goodDecimal;
            }
            return resul;
        }

        public static DateTime? GetDateFromUser(string dataName)
        {
            DateTime? resul = null;
            AskUserForData($"{dataName} (dd-MM-yyyy)");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime goodDate) == true)
            {
                resul = goodDate;
            }
            return resul;
        }
    }
}
