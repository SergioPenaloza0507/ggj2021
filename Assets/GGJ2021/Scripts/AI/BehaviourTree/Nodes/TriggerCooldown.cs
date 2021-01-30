using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCooldown : BhNode
{
    [SerializeField] float cooldownValue;
    public override bool Execute(BhForwardedData data)
    {
        Debug.Log(this);
        data.SetValue("Cooldown", cooldownValue);
        return true;
    }
}
