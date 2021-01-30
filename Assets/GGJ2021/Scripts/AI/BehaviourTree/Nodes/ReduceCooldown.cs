using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceCooldown : BhNode
{
    [SerializeField] float deltaTimeMultiplier;

    public override bool Execute(BhForwardedData data)
    {
        Debug.Log(this);
        if (data.TryGetValue("Cooldown", out float val))
        {
            var cl = val - Time.deltaTime * deltaTimeMultiplier;
            Debug.Log(cl);
            data.SetValue("Cooldown", cl);
        }
        return true;
    }
}
