using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serilizable]
public class BhForwardedData
{
    Dictionary<Tuple<string, Type>, object> data = new Dictionary<Tuple<string, Type>, object>();

    public void DeleteValue<T>(string name)
    {
        Type t = typeof(T);
        var k = new Tuple<string, Type>(name, t);
        if (!data.ContainsKey(k))
        {
            return;
        }
        data.Remove(k);
    }

    public void SetValue<T>(string name, T value)
    {
        Type t = typeof(T);
        var k = new Tuple<string, Type>(name, t);
        if (!data.ContainsKey(k))
        {
            data.Add(k, value);
        }
        else
        {
            data[k] = value;
        }
    }

    public bool TryGetValue<T>(string name, out T result)
    {
        Type t = typeof(T);
        var k = new Tuple<string, Type>(name, t);
        result = default;
        if (!data.ContainsKey(k))
        {
            return false;
        }
        try
        {
            result = (T)data[k];
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool TryGetValue(string name, Type t, out object result)
    {
        var k = new Tuple<string, Type>(name, t);
        result = false;
        if (!data.ContainsKey(k))
        {
            return false;
        }
        try
        {
            result = data[k];
            return true;
        }
        catch
        {
            return false;
        }
    }
}
