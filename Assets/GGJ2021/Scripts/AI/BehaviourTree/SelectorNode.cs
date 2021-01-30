using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectorNode : BhNode
{
    [SerializeField] BhNode positiveChild, negativeChild;
    public override bool Execute()
    {
        if (CheckCondition())
        {
            return positiveChild.Execute();
        }
        else 
        {
            return negativeChild.Execute();
        }
    }

    protected abstract bool CheckCondition();
}
