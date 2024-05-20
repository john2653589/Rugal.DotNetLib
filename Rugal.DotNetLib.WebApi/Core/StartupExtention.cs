using Microsoft.Extensions.DependencyInjection;
using Rugal.DotNetLib.WebApi.JsonConverters;

namespace Rugal.DotNetLib.WebApi.Core
{
    public static class StartupExtention
    {
        public static IServiceCollection AddDotNetLib_Core(this IServiceCollection Services)
        {
            Services.AddDotNetLib_JsonConvertAll();
            return Services;
        }
    }
}