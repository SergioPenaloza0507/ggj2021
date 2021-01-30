using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class DetectNode : SelectorNode
{
    [SerializeField] float radius;
    [SerializeField] LayerMask mask;
    [SerializeField] string expecteTags;
    [SerializeField] Vector3 offset;

    protected override bool CheckCondition(BhForwardedData data)
    {
        Debug.Log(this);
        var cols = Physics.OverlapSphere(transform.position + offset, radius, mask);
        for (int i = 0; i < cols.Length; i++)
        {
            var col = cols[i];
            if (col.gameObject.CompareTag(expecteTags))
            {
                data.SetValue("Tracked", col.gameObject);
                return true;
            }
        }
        return false;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + offset, radius);
        Handles.Label(transform.position + offset + Vector3.up * radius, "Detection adius");
    }
#endif
}
