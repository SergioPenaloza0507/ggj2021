using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectorNode : BhNode
{
    [SerializeField] BhNode positiveChild, negativeChild;
    public override bool Execute(BhForwardedData data)
    {
        if (CheckCondition())
        {
            return positiveChild.Execute(data);
        }
        else 
        {
            return negativeChild.Execute(data);
        }
    }

    protected abstract bool CheckCondition();
}
