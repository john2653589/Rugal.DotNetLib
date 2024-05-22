using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;

namespace Rugal.DotNetLib.WebApi.FormDataConverters
{
    public static class StartupExtention
    {
        public static IServiceCollection AddDotNetLib_FormDataJson(this IServiceCollection Services)
        {
            Services.AddDotNetLib_FormDataJson(null);
            return Services;
        }
        public static IServiceCollection AddDotNetLib_FormDataJson(this IServiceCollection Services, Action<FormDataJsonOption> ConfigFunc)
        {
            var NewOption = new FormDataJsonOption();
            ConfigFunc?.Invoke(NewOption);

            Services.AddControllers(Options =>
            {
                Options.ValueProviderFactories
                   .Where(Item => Item is FormValueProviderFactory || Item is JQueryFormValueProviderFactory)
                   .ToList()
                   .ForEach(Item => Options.ValueProviderFactories.Remove(Item));

                Options.ValueProviderFactories.Insert(0, new FormDataNullableProviderFactory());
                Options.ModelBinderProviders.Insert(0, new FormDataJsonBinderProvider(NewOption));
            });
            return Services;
        }
    }
}