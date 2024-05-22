using Microsoft.AspNetCore.Mvc.ModelBinding;
using Rugal.DotNetLib.Core.JsonConverters;
using System.Collections;
using System.Text.Json;

namespace Rugal.DotNetLib.WebApi.FormDataConverters
{
    public class FormDataJsonBinder : IModelBinder
    {
        private readonly FormDataJsonOption Option;
        public FormDataJsonBinder(FormDataJsonOption _Option)
        {
            Option = _Option;
        }

        private static readonly JsonSerializerOptions JsonOption = CreateNewJsonOption();
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (TryParseJson(bindingContext))
                return Task.CompletedTask;

            if (TryParseFile(bindingContext))
                return Task.CompletedTask;

            return Task.CompletedTask;
        }
        public bool TryParseJson(ModelBindingContext bindingContext)
        {
            try
            {
                var JsonString = bindingContext.ValueProvider.GetValue(Option.FormDataBodyKey).ToString();
                var JsonResult = JsonSerializer.Deserialize(JsonString, bindingContext.ModelType, JsonOption);
                bindingContext.Result = ModelBindingResult.Success(JsonResult);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public static bool TryParseFile(ModelBindingContext bindingContext)
        {
            try
            {
                var FieldName = bindingContext.FieldName;
                var GetValue = bindingContext.ValueProvider.GetValue(FieldName);
                var IsArray = bindingContext.ModelType
                    .GetInterfaces()
                    .Any(Item => Item == typeof(IEnumerable));

                if (IsArray)
                {
                    var Files = bindingContext.HttpContext.Request.Form.Files.GetFiles(FieldName);
                    bindingContext.Result = ModelBindingResult.Success(Files);
                }
                else
                {
                    var File = bindingContext.HttpContext.Request.Form.Files.GetFile(FieldName);
                    bindingContext.Result = ModelBindingResult.Success(File);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        private static JsonSerializerOptions CreateNewJsonOption()
        {
            var Result = new JsonSerializerOptions();
            Result.Converters.AddDotNetLib_JsonConverter();
            return Result;
        }
    }
    public class FormDataJsonBinderProvider : IModelBinderProvider
    {
        private readonly FormDataJsonOption Option;
        public FormDataJsonBinderProvider(FormDataJsonOption _Option)
        {
            Option = _Option ?? new FormDataJsonOption();
        }
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var BindingSource = context.BindingInfo.BindingSource;
            if (BindingSource is not null)
            {
                if (BindingSource.CanAcceptDataFrom(BindingSource.Body))
                    return null;

                if (BindingSource.CanAcceptDataFrom(BindingSource.Query))
                    return null;
            }
            return new FormDataJsonBinder(Option);
        }
    }
}