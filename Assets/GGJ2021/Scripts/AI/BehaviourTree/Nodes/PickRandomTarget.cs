using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(NavMeshAgent))]
public class PickRandomTarget : BhNode
{
    NavMeshAgent ag;
    [SerializeField] float radius;

    private void Awake()
    {
        ag = GetComponent<NavMeshAgent>();
    }

    public override bool Execute(BhForwardedData data)
    {
        Debug.Log(this);
        var a = Random.insideUnitCircle;
        Vector3 randomVector = new Vector3(a.x, 0, a.y) * radius;
        Debug.DrawLine(transform.position, transform.position + randomVector);
        if (data.TryGetValue("RoamingTracker", out GameObject roamingTarget))
        {
            Debug.Log("E");
            roamingTarget.transform.position = transform.position + randomVector;
            data.SetValue("Tracked", roamingTarget);
        }
        ag.destination = transform.position + randomVector;
        return true;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.magenta;
        Handles.Label(transform.position + transform.forward * radius, "Random Position Picker");
        Handles.DrawWireArc(transform.position, Vector3.up, transform.forward,360,radius);
    }
#endif
}
