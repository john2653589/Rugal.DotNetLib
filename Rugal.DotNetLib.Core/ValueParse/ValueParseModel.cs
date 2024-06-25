
namespace Rugal.DotNetLib.Core.ValueParse
{
    public record class ValueParseMapping(Type ValueType, Func<string, object> ParseFunc)
    {
        public Type ValueType { get; set; } = ValueType;
        public Func<string, object> ParseFunc { get; set; } = ParseFunc;
    }
}