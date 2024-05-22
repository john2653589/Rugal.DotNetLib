using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace Rugal.DotNetLib.Http.FormDataConverters
{
    public class FormDataNullableProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            var HttpContext = context.ActionContext.HttpContext;
            if (HttpContext.Request.HasFormContentType)
            {
                var FormValueProvider = new FormDataNullableProvider(
                    BindingSource.Form,
                    HttpContext.Request.Form,
                    CultureInfo.InvariantCulture);
                context.ValueProviders.Add(FormValueProvider);
            }
            return Task.CompletedTask;
        }
    }
    public class FormDataNullableProvider : FormValueProvider
    {
        public FormDataNullableProvider(BindingSource bindingSource, IFormCollection values, CultureInfo culture) : base(bindingSource, values, culture)
        {
        }
        public override ValueProviderResult GetValue(string key)
        {
            var Value = base.GetValue(key);
            var EmptyValue = new[] { "null", "", @"""""", "''" }
                .Select(Item => new ValueProviderResult(Item));

            if (EmptyValue.Any(Item => Item == Value))
            {
                var None = ValueProviderResult.None;
                return None;
            }
            return Value;
        }
    }
}
