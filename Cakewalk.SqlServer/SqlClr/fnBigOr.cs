using Microsoft.SqlServer.Server;
using System;
using System.Data.SqlTypes;

/// <summary>
/// Aggregate function to perform a bitwise OR on a group of big integers.
/// </summary>
[Serializable]
[SqlUserDefinedAggregate(Format.Native)]
public struct fnBigOr
{
    public long BitField;

    public void Init()
    {
        this.BitField = 0;
    }

    public void Accumulate(SqlInt64 value)
    {
        this.BitField |= value.Value;
    }

    public void Merge(fnBigOr group)
    {
        this.BitField |= group.BitField;
    }

    public SqlInt64 Terminate()
    {
        return new SqlInt64(this.BitField);
    }
}
