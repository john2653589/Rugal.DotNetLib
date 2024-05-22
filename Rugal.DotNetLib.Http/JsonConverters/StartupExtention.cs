using Microsoft.Extensions.DependencyInjection;
using Rugal.DotNetLib.Core.JsonConverters;
using Rugal.DotNetLib.Http.JsonConverters;

namespace Rugal.DotNetLib.Http.JsonConverters
{
    public static class StartupExtention
    {
        public static IServiceCollection AddDotNetLib_JsonConvertAll(this IServiceCollection Services)
        {
            Services.AddDotNetLib_JsonConvertOption()
                .AddDotNetLib_JsonConverter();

            return Services;
        }
        public static IServiceCollection AddDotNetLib_JsonConvertOption(this IServiceCollection Services)
        {
            Services.AddControllers().AddJsonOptions(Options =>
            {
                Options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            return Services;
        }
        public static IServiceCollection AddDotNetLib_JsonConverter(this IServiceCollection Services)
        {
            Services.AddControllers().AddJsonOptions(Options =>
            {
                Options.JsonSerializerOptions.Converters.AddDotNetLib_JsonConverter();
            });
            return Services;
        }
    }
}