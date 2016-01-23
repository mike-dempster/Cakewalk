using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

public partial class UserDefinedFunctions
{
    /// <summary>
    /// Gets a sequence from the input string that matches the regular expression pattern.
    /// </summary>
    /// <param name="input">Input string to find the match in.</param>
    /// <param name="pattern">Regular expression pattern to search for in the input string.</param>
    /// <returns>Sequence from the input string that matches the regular expression pattern.</returns>
    [SqlFunction]
    public static SqlString fnRegexMatch(SqlString input, SqlString pattern)
    {
        string inputString = input.Value;
        string patternString = pattern.Value;

        var match = Regex.Match(inputString, patternString);

        if (false == match.Success)
        {
            return new SqlString(string.Empty);
        }

        return new SqlString(match.Value);
    }
}
