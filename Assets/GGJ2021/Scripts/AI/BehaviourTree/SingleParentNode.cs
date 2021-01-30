using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleParentNode : BhNode
{
    [SerializeField] protected BhNode child; 
    public override bool Execute(BhForwardedData data)
    {
        ExecuteExtra(data);
        return child.Execute(data);
    }

    protected abstract void ExecuteExtra(BhForwardedData data);
}
