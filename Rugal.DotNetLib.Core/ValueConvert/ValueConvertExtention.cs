namespace Rugal.DotNetLib.Core.ValueConvert
{
    public static class ConvertersExtention
    {
        public static TimeSpan TryToTimeSpan(this string GetValue)
        {
            if (TimeSpan.TryParse(GetValue, out var Value))
                return Value;
            return TimeSpan.Zero;
        }
        public static TimeSpan? TryToTimeSpanNull(this string GetValue)
        {
            if (TimeSpan.TryParse(GetValue, out var Value))
                return Value;
            return null;
        }
        public static DateTime TryToDateTime(this string GetValue)
        {
            if (DateTime.TryParse(GetValue, out var Value))
                return Value;
            return DateTime.MinValue;
        }
        public static DateTime? TryToDateTimeNull(this string GetValue)
        {
            if (DateTime.TryParse(GetValue, out var Value))
                return Value;
            return null;
        }
        public static DateOnly TryToDateOnly(this string GetValue)
        {
            if (DateOnly.TryParse(GetValue, out var Value))
                return Value;
            return DateOnly.MinValue;
        }
        public static DateOnly? TryToDateOnlyNull(this string GetValue)
        {
            if (DateOnly.TryParse(GetValue, out var Value))
                return Value;
            return null;
        }
        public static bool TryToBool(this string GetValue)
        {
            if (bool.TryParse(GetValue, out var Value))
                return Value;
            return false;
        }
        public static bool? TryToBoolNull(this string GetValue)
        {
            if (bool.TryParse(GetValue, out var Value))
                return Value;
            return null;
        }
        public static Guid TryToGuid(this string GetValue)
        {
            if (Guid.TryParse(GetValue, out var Value))
                return Value;
            return Guid.Empty;
        }
        public static Guid? TryToGuidNull(this string GetValue)
        {
            if (Guid.TryParse(GetValue, out var Value))
                return Value;
            return null;
        }
        public static int TryToInt(this string GetValue)
        {
            if (int.TryParse(GetValue, out var Value))
                return Value;
            return 0;
        }
        public static int? TryToIntNull(this string GetValue)
        {
            if (int.TryParse(GetValue, out var Value))
                return Value;
            return null;
        }
    }
}