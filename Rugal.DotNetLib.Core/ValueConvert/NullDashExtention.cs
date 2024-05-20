using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Rugal.DotNetLib.Core.ValueConvert
{
    public static class NullDashExtention
    {
        private static IServiceProvider Provider;
        private static NullDashOption Option => GetOption();
        public static IServiceCollection UsingNullDash(this IServiceCollection Services, Action<NullDashOption> ConfigFunc)
        {
            Services.Configure(ConfigFunc);
            Provider = Services.BuildServiceProvider();
            return Services;
        }
        public static string ToNullDash<TValue>(this TValue Value)
        {
            if (Value is null)
                return "---";

            return CustomToString(Value);
        }
        public static string ToNullDash<TValue>(this TValue Value, string Format)
        {
            if (Value is null)
                return "---";

            return CustomToString(Value, Format);
        }
        public static string ToNullDash<TModel, TValue>(this TModel Model, Func<TModel, TValue> GetValueFunc)
        {
            if (Model is null)
                return "---";

            var Value = GetValueFunc(Model);
            return CustomToString(Value);
        }
        private static string CustomToString(object Value, string Format = null)
        {
            if (Value is string StringValue)
                return StringValue;

            if (Option.IsUsingCusToString)
            {
                if (Value is DateTime DateTimeValue)
                    return DateTimeValue.ToCusString(Format);

                if (Value is DateOnly DateOnlyValue)
                    return DateOnlyValue.ToCusString(Format);

                if (Value is TimeSpan TimeSpanValue)
                    return TimeSpanValue.ToCusString(Format);
            }

            return Value.ToString();
        }
        private static NullDashOption GetOption()
        {
            var Setting = Provider?
                .GetRequiredService<IOptions<NullDashOption>>()?.Value;

            Setting ??= new NullDashOption();
            return Setting;
        }
    }
    public class NullDashOption
    {
        public bool IsUsingCusToString { get; set; } = true;
    }
}
