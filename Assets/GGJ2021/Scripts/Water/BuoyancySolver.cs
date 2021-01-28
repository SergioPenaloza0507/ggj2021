using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class BuoyancySolver : MonoBehaviour
{
    Rigidbody rb;
    Collider col;
    [SerializeField] Vector3 buoyantPivot;
    [SerializeField] Vector3 checkBounds;
    [SerializeField] float delay, minHeight;
    float counter;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= delay)
        {
            if (CheckForOcean(out Terrain t, out Ocean o))
            {
                Debug.Log("Ocean Detected");
                col.isTrigger = true;
                SolveBuoyancy(t, o);
            }
            else
            {
                //col.isTrigger = false;
            }
            counter = 0;
            
        }
        if (transform.position.y < minHeight)
        {
            rb.AddForce(Vector3.up * rb.velocity.magnitude * 2);
        }
    }


    void SolveBuoyancy(Terrain t, Ocean o)
    {
        //Fb = ρgV = ρghA
        //ρ = DENSITY
        //g = GRAVITATIONAL ACCELERATION
        //V = VOLUME
        //h = HEIGHT OF DISPLACED FLUID
        //A = OBJECT SURFACE AREA

        float height = t.SampleHeight(transform.position);
        var relative = transform.position + buoyantPivot;
        float displcaedHeight = Vector3.Distance(relative, new Vector3(relative.x, height, relative.z));
        Vector3 force = Vector3.up * rb.velocity.magnitude  * o.density * Physics.gravity.y * displcaedHeight * col.bounds.extents.x;
        if(force.y < 0)
        {
            force = new Vector3(force.x, -force.y, force.z);
        }
        Debug.DrawLine(transform.position, transform.position + force,Color.black,5);
        rb.AddForce(force, ForceMode.Impulse);
    }
    bool CheckForOcean(out Terrain t, out Ocean o)
    {
        bool ret = false;
        t = null;
        o = null;
        var cols = Physics.OverlapBox(transform.position + buoyantPivot, checkBounds);
        foreach(var col in cols)
        {
            if(col.TryGetComponent(out t) && col.TryGetComponent(out o))
            {
                return true;
            }
        }
        return ret;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + buoyantPivot, checkBounds);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + buoyantPivot, 0.2f);
        Gizmos.DrawCube(new Vector3(transform.position.x, minHeight, transform.position.z), new Vector3(10, 0.2f, 10));
    }
#endif
}
