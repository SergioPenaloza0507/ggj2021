using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TrackTarget : BhNode
{
    NavMeshAgent ag;

    private void Awake()
    {
        ag = GetComponent<NavMeshAgent>();
    }

    public override bool Execute(BhForwardedData data)
    {
        Debug.Log(this);
        if (data.TryGetValue("Tracked", out GameObject g))
        {
            ag.destination = g.transform.position;
            return true;
        }
        return false;
    }
}
