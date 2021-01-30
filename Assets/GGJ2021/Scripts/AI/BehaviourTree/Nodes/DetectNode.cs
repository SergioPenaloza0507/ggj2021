using UnityEngine;

public class DetectNode : SelectorNode
{
    [SerializeField] float radius;
    [SerializeField] LayerMask mask;
    [SerializeField] string expecteTags;
    [SerializeField] Vector3 offset;

    protected override bool CheckCondition()
    {
        var cols = Physics.OverlapSphere(transform.position + offset, radius, mask);
        for (int i = 0; i < cols.Length; i++)
        {
            var col = cols[i];
            if (col.gameObject.CompareTag(expecteTags))
            {
                return true;
            }
        }
        return false;
    }
}
