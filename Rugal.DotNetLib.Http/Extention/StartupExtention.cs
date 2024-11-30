using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Rugal.ConfigFiller.Core.Extention;
using Rugal.DotNetLib.Core.ValueParse;
using Rugal.DotNetLib.Http.Cors;
using Rugal.DotNetLib.Http.FormDataConverters;
using Rugal.DotNetLib.Http.JsonConverters;

namespace Rugal.DotNetLib.Http.Extention
{
    public static class StartupExtention
    {
        public static IHostApplicationBuilder AddDotNetLib_HttpCore(this IHostApplicationBuilder Builder)
        {
            Builder.Configuration
                .AddConfigFiller();

            Builder.Services
                .AddDotNetLib_ValueParse()
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