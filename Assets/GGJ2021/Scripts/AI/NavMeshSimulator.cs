using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshSimulator : MonoBehaviour
{
    Terrain t;
    NavMeshAgent nav;
    [SerializeField] float heightOffset;

    Vector3 last;
    // Start is called before the first frame update
    void Awake()
    {
        t = FindObjectOfType<Terrain>();
        nav = GetComponent<NavMeshAgent>();
        nav.updatePosition = false;
    }

    private void Update()
    {
        if (nav.hasPath)
        {
            nav.updatePosition = false;
            Vector3 nt = nav.nextPosition;
            last = new Vector3(nt.x, t.SampleHeight(nt) + heightOffset, nt.z);
            transform.position = last;
        }
        else
        {
            nav.updatePosition = true;
        }
    }
}
