using Microsoft.SqlServer.Server;
using System;
using System.Data.SqlTypes;

/// <summary>
/// Aggregate function to perform a bitwise AND on a group of integers.
/// </summary>
[Serializable]
[SqlUserDefinedAggregate(Format.Native)]
public struct fnAnd
{
    public int BitField;

    public void Init()
    {
        this.BitField = -1;
    }

    public void Accumulate(SqlInt32 value)
    {
        this.BitField &= value.Value;
    }

    public void Merge(fnAnd group)
    {
        this.BitField &= group.BitField;
    }

    public SqlInt32 Terminate()
    {
        return new SqlInt32(this.BitField);
    }
}
