using System.Text.RegularExpressions;

namespace Rugal.DotNetLib.Core.TimeConvert;

public static class TimeSpanExtention
{
    public static TimeSpan AddParse(this TimeSpan Span, string TimeString)
    {
        var AddTime = BaseParse(TimeString);
        var Result = Span.Add(AddTime);
        return Result;
    }
    public static TimeSpan ParseTimeString(this string TimeString)
    {
        return BaseParse(TimeString);
    }
    private static TimeSpan BaseParse(string TimeString)
    {
        var Result = TimeSpan.Zero;
        var RegexUnits = Regex.Matches(TimeString, @"[a-z]+");
        if (RegexUnits.Count == 0)
            return Result;

        var RegexTimes = Regex.Matches(TimeString, @"\d+");
        if (RegexTimes.Count == 0)
            return Result;

        var UnitChars = RegexUnits
            .Select(Item => Item.Value)
            .ToArray();

        var Times = RegexTimes
            .Select(Item => int.Parse(Item.Value))
            .ToArray();

        for (var i = 0; i < UnitChars.Length; i++)
        {
            if (i >= Times.Length)
                break;

            var Unit = UnitChars[i];
            var Time = Times[i];
            var AddTime = Unit switch
            {
                "d" => TimeSpan.FromDays(Time),
                "h" => TimeSpan.FromHours(Time),
                "m" => TimeSpan.FromMinutes(Time),
                "s" => TimeSpan.FromSeconds(Time),
                _ => TimeSpan.Zero,
            };
            Result = Result.Add(AddTime);
        }
        return Result;
    }
}
