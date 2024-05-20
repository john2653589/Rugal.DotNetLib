using System.Globalization;

namespace Rugal.DotNetLib.Core.DateConvert
{
    public static class TaiwanDateExtention
    {
        public static string ToTaiwanDateTime(this DateTime ConvertDateTime, string Format = "y-MM-dd HH:mm:ss")
        {
            var Result = ToTaiwanFormat(ConvertDateTime, Format);
            return Result;
        }
        public static string ToTaiwanDate(this DateTime ConvertDateTime, string Format = "y-MM-dd")
        {
            var Result = ToTaiwanFormat(ConvertDateTime, Format);
            return Result;
        }
        public static int GetTaiwanYear(this DateTime ConvertDateTime)
        {
            var TwCalendar = new TaiwanCalendar();
            var TaiwanYear = TwCalendar.GetYear(ConvertDateTime);
            return TaiwanYear;
        }
        private static string ToTaiwanFormat(DateTime ConvertDateTime, string Format)
        {
            var TaiwanYear = GetTaiwanYear(ConvertDateTime);
            while (Format.Contains("yy"))
                Format = Format.Replace("yy", "y");

            Format = Format.Replace("y", TaiwanYear.ToString());
            var Result = ConvertDateTime.ToString(Format);
            return Result;
        }
    }
}