using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : BhNode
{
    [SerializeField] BhNode[] children;

    public override bool Execute()
    {
        for (int i = 0; i < children.Length; i++)
        {
            
        }
        return true;
    }
}
