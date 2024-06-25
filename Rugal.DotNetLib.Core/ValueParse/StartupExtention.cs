using Microsoft.Extensions.DependencyInjection;
using Rugal.DotNetLib.Core.ValueConvert;

namespace Rugal.DotNetLib.Core.ValueParse
{
    public static class StartupExtention
    {
        public static IServiceCollection AddDotNetLib_ValueParse(this IServiceCollection Services)
        {
            Services.AddScoped<ValueParseService>()
                .Configure(DefaultConfig());
            return Services;
        }

        public static IServiceCollection AddDotNetLib_ValueParse(this IServiceCollection Services, Action<ValueParseConfig> OptionFunc)
        {
            Services.AddDotNetLib_ValueParse()
                .Configure(OptionFunc);

            return Services;
        }

        private static Action<ValueParseConfig> DefaultConfig()
        {
            return (Option) =>
            {
                Option
                    .WithMap(typeof(TimeSpan), Value => Value.TryToTimeSpan())
                    .WithMap(typeof(TimeSpan?), Value => Value.TryToTimeSpan())
                    .WithMap(typeof(DateTime), Value => Value.TryToDateTime())
                    .WithMap(typeof(DateTime?), Value => Value.TryToDateTimeNull())
                    .WithMap(typeof(DateOnly), Value => Value.TryToDateOnly())
                    .WithMap(typeof(DateOnly?), Value => Value.TryToDateOnlyNull())
                    .WithMap(typeof(bool), Value => Value.TryToBool())
                    .WithMap(typeof(bool?), Value => Value.TryToBoolNull())
                    .WithMap(typeof(Guid), Value => Value.TryToGuid())
                    .WithMap(typeof(Guid?), Value => Value.TryToGuidNull())
                    .WithMap(typeof(int), Value => Value.TryToInt())
                    .WithMap(typeof(int?), Value => Value.TryToIntNull());
            };
        }
    }
}