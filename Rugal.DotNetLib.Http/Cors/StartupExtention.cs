using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Rugal.DotNetLib.Http.Cors
{
    public static class StartupExtention
    {
        public static IServiceCollection AddDotNetLib_Cors(
            this IServiceCollection Services, IConfiguration Configuration, IHostEnvironment Env)
        {
            Services.AddCors(options =>
            {
                var GetCors = Configuration["Cors"];
                if (Env.IsDevelopment())
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowCredentials();
                        builder.SetIsOriginAllowed(origin =>
                        {
                            var IsAllowed = new Uri(origin).Host.Contains("localhost", StringComparison.CurrentCultureIgnoreCase);
                            return IsAllowed;
                        });
                    });
                }
                else if (!string.IsNullOrWhiteSpace(GetCors))
                {
                    var CorsOrigins = GetCors
                        .Split(';')
                        .Select(Item => Item.Trim(' '))
                        .ToArray();

                    options.AddDefaultPolicy(builder =>
                    {
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowCredentials();
                        builder.WithOrigins(CorsOrigins);
                    });
                }
            });
            return Services;
        }
        public static void UsingDotNetLib_Cors(this IApplicationBuilder App)
        {
            App.UseCors();
        }
    }
}
