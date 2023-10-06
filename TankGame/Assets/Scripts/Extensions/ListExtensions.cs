using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static bool HasElements<T>(this List<T> list)
    {
        return list != null && list.Count > 0;
    }
}
