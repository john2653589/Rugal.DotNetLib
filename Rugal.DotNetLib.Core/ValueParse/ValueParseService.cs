using Microsoft.Extensions.Options;

namespace Rugal.DotNetLib.Core.ValueParse
{
    public class ValueParseService
    {
        private readonly ValueParseConfig Config;
        public ValueParseService(IOptions<ValueParseConfig> _Option)
        {
            Config = _Option.Value;
        }

        public object TryParse(string Value, Type ValueType)
        {
            if (Value is null)
                return default;

            var GetConfig = Config.Mapping.FirstOrDefault(Item => Item.ValueType == ValueType);
            if (GetConfig is null)
                return default;

            var ParseResult = GetConfig.ParseFunc(Value);
            return ParseResult;
        }
    }
}