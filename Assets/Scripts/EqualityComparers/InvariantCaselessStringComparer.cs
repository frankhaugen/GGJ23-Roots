using System;
using System.Collections.Generic;

internal class InvariantCaselessStringComparer : IEqualityComparer<string>
{
    public bool Equals(string x, string y)
    {
        return string.Equals(x, y, StringComparison.InvariantCultureIgnoreCase);
    }

    public int GetHashCode(string obj)
    {
        return obj.ToLowerInvariant().GetHashCode();
    }
}