using Microsoft.SqlServer.Server;
using System;
using System.Data.SqlTypes;

/// <summary>
/// Aggregate function to perform a bitwise OR on a group of big integers.
/// </summary>
[Serializable]
[SqlUserDefinedAggregate(Format.Native)]
public struct fnOr
{
    public int BitField;

    public void Init()
    {
        this.BitField = 0;
    }

    public void Accumulate(SqlInt32 value)
    {
        this.BitField |= value.Value;
    }

    public void Merge(fnOr group)
    {
        this.BitField |= group.BitField;
    }

    public SqlInt32 Terminate()
    {
        return new SqlInt32(this.BitField);
    }
}
