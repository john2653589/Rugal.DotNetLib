using Microsoft.Extensions.Hosting;
using Rugal.DotNetLib.Core.ValueParse;

namespace Rugal.DotNetLib.Core
{
    public static class StartupExtention
    {
        public static IHostApplicationBuilder AddDotNetLib_Core(this IHostApplicationBuilder Builder)
        {
            Builder.Services.AddDotNetLib_ValueParse();
            return Builder;
        }
    }
}