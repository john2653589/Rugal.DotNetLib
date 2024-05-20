using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Rugal.DotNetLib.Core.ValueConvert
{
    public static class ToCusStringExtention
    {
        private static IServiceProvider Provider;
        private static CusStringOption Option => GetOption();
        public static IServiceCollection UsingCusString(this IServiceCollection Services, Action<CusStringOption> ConfigFunc)
        {
            Services.Configure(ConfigFunc);
            Provider = Services.BuildServiceProvider();
            return Services;
        }
        public static string ToCusString(this TimeSpan Value, string Format = null)
        {
            Format ??= Option.TimeSpanFormatDefault;
            var Result = Value.ToString(Format);
            return Result;
        }
        public static string ToCusString(this DateTime Value, string Format = null)
        {
            var FormatString = Option.DateTimeFormatDefault;
            if (Format is not null)
                FormatString = Format;
            else if (Value.Hour == 0 && Value.Minute == 0 && Value.Second == 0 && Value.Millisecond == 0)
                FormatString = Option.DateTimeOnlyDateFormatDefault;

            var Result = Value.ToString(FormatString);
            return Result;
        }
        public static string ToCusString(this DateOnly Value, string Format = null)
        {
            Format ??= Option.DateOnlyFormatDefault;
            var Result = Value.ToString(Format);
            return Result;
        }
        private static CusStringOption GetOption()
        {
            var Setting = Provider?
                .GetRequiredService<IOptions<CusStringOption>>()?
                .Value;

            Setting ??= new CusStringOption();
            return Setting;
        }
    }
    public class CusStringOption
    {
        public string TimeSpanFormatDefault { get; set; } = @"hh\:mm\:ss";
        public string DateTimeFormatDefault { get; set; } = "yyyy-MM-dd HH:mm:ss";
        public string DateTimeOnlyDateFormatDefault { get; set; } = "yyyy-MM-dd";
        public string DateOnlyFormatDefault { get; set; } = "yyyy-MM-dd";
    }
}