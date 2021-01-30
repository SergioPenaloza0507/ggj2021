using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : BhNode
{
    [SerializeField] BhNode[] children;
    [SerializeField] bool truncateOnPositive;
    public override bool Execute(BhForwardedData data)
    {
        for (int i = 0; i < children.Length; i++)
        {
            bool result = children[i].Execute(data);
            if (truncateOnPositive)
            {
                if (result)
                {
                    break;
                }
            }
        }
        return true;
    }
}
