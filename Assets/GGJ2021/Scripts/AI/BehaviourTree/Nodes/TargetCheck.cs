using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCheck : SelectorNode
{
    protected override bool CheckCondition(BhForwardedData data)
    {
        Debug.Log(this);
        if(data.TryGetValue("Tracked", out GameObject g))
        {
            return true;
        }
        return false;
    }
}
