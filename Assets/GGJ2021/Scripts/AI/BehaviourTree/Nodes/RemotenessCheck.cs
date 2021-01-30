using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemotenessCheck : SelectorNode
{
    [SerializeField] float distance;
    protected override bool CheckCondition(BhForwardedData data)
    {
        Debug.Log(this);
        if (data.TryGetValue("Tracked", out GameObject g))
        {
            if (Vector3.Distance(transform.position, g.transform.position) > distance)
            {
                data.DeleteValue<GameObject>("Tracked");
                return true;
            }
        }
        return false;
    }
}
