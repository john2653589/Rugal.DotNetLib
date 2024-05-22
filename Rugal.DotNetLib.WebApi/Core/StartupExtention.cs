using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Rugal.DotNetLib.WebApi.Cors;
using Rugal.DotNetLib.WebApi.FormDataConverters;
using Rugal.DotNetLib.WebApi.JsonConverters;

namespace Rugal.DotNetLib.WebApi.Core
{
    public static class StartupExtention
    {
        public static IHostApplicationBuilder AddDotNetLib_Core(this IHostApplicationBuilder Builder)
        {
            Builder.Services
                .AddDotNetLib_JsonConvertAll()
                .AddDotNetLib_Cors(Builder.Configuration, Builder.Environment)
                .AddDotNetLib_FormDataJson();

            return Builder;
        }
        public static IApplicationBuilder UsingDotNetLib_Core(this IApplicationBuilder App)
        {
            App.UsingDotNetLib_Cors();
            return App;
        }
    }
}