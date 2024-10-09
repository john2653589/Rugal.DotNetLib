namespace Rugal.DotNetLib.Core.DateConvert
{
    public static class DateOnlyExtention
    {
        public static DateTime ToDateTime(this DateOnly ConvertDate)
        {
            var NewDateTime = new DateTime(ConvertDate.Year, ConvertDate.Month, ConvertDate.Day);
            return NewDateTime;
        }
        public static DateOnly ToDateOnly(this DateTime ConvertDateTime)
        {
            var NewDateOnly = DateOnly.FromDateTime(ConvertDateTime);
            return NewDateOnly;
        }
    }
}