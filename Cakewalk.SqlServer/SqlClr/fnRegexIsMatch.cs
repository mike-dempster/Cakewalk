using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

public partial class UserDefinedFunctions
{
    /// <summary>
    /// Checks if a regular expression pattern matches a sequence in the input string.
    /// </summary>
    /// <param name="input">Input string to check for a match.</param>
    /// <param name="pattern">Regular expression pattern to search for in the input string.</param>
    /// <returns>true if a match is found; otherwise false.</returns>
    [SqlFunction]
    public static SqlBoolean fnRegexIsMatch(SqlString input, SqlString pattern)
    {
        string regexInput = input.Value;
        string regexPattern = pattern.Value;
        bool isMatch = Regex.IsMatch(regexInput, regexPattern);

        return new SqlBoolean(isMatch);
    }
}
