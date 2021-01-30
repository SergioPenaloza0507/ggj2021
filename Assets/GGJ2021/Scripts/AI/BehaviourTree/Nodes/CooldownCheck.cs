using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownCheck : SelectorNode
{
    [SerializeField] string propertyName;
    protected override bool CheckCondition(BhForwardedData data)
    {
        Debug.Log(this);
        if (data.TryGetValue(propertyName,out float cooldown))
        {
            return cooldown > 0;
        }
        return false;
    }
}
