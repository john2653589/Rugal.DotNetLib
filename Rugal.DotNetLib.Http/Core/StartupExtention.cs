using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Rugal.DotNetLib.Http.Cors;
using Rugal.DotNetLib.Http.FormDataConverters;
using Rugal.DotNetLib.Http.JsonConverters;

namespace Rugal.DotNetLib.Http.Core
{
    public static class StartupExtention
    {
        public static IHostApplicationBuilder AddDotNetLib_HttpCore(this IHostApplicationBuilder Builder)
        {
            Builder.Services
                .AddDotNetLib_JsonConvertAll()
                .AddDotNetLib_Cors(Builder.Configuration, Builder.Environment)
                .AddDotNetLib_FormDataJson();

            return Builder;
        }
        public static IApplicationBuilder UsingDotNetLib_HttpCore(this IApplicationBuilder App)
        {
            App.UsingDotNetLib_Cors();
            return App;
        }
    }
}