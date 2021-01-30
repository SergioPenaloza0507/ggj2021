using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCheck : SelectorNode
{
    [SerializeField] string propertyName;
    protected override bool CheckCondition(BhForwardedData data)
    {
        if (data.TryGetValue(propertyName, out bool moving))
        {
            return moving;
        }
        return false;
    }
}
