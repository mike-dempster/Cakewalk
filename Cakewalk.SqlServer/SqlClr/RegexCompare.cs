using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

public partial class UserDefinedFunctions
{
    /// <summary>
    /// Compares two input strings by the sequences that match the regular expression pattern.
    /// </summary>
    /// <param name="leftInput">Input string for the left side of the comparison.</param>
    /// <param name="rightInput">Input string for the right side of the comparison.</param>
    /// <param name="pattern">Regular expression to use for comparison of the two strings.</param>
    /// <returns>true if the matching sequences of the two input strings match; otherwise false.</returns>
    [SqlFunction]
    public static SqlBoolean RegexCompare(SqlString leftInput, SqlString rightInput, SqlString pattern)
    {
        string leftInputString = leftInput.Value;
        string rightInputString = rightInput.Value;
        string patternString = pattern.Value;

        var leftMatch = Regex.Match(leftInputString, patternString);

        if (false == leftMatch.Success)
        {
            return new SqlBoolean(false);
        }

        var rightMatch = Regex.Match(rightInputString, patternString);

        if (false == rightMatch.Success)
        {
            return new SqlBoolean(false);
        }

        bool isMatch = leftMatch.Value == rightMatch.Value;

        return new SqlBoolean(isMatch);
    }
}
