using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serilizable]
public class BhForwardedData
{
    Dictionary<Tuple<string, Type>, object> data = new Dictionary<Tuple<string, Type>, object>();

    public T GetValue<T>(string name)
    {
        Type t = typeof(T);
        var k = new Tuple<string, Type>(name, t);
        if (!data.ContainsKey(k))
        {
            return default;
        }
        try
        {
            return (T)data[k];
        }
        catch
        {
            return default;
        }
    }
}
