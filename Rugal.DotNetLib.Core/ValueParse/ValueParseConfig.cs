
namespace Rugal.DotNetLib.Core.ValueParse
{
    public class ValueParseConfig
    {
        public List<ValueParseMapping> Mapping { get; set; }
        public ValueParseConfig()
        {
            Mapping = [];
        }
        public ValueParseConfig WithMap(Type ValueType, Func<string, object> ParseFunc)
        {
            Mapping.Add(new ValueParseMapping(ValueType, ParseFunc));
            return this;
        }
    }
}