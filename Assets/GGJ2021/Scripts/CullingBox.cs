using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CullingBox : MonoBehabiourSingleton<CullingBox>
{
    [SerializeField] Vector3 relativePosition;
    [SerializeField] Vector3 extents;

    public Vector3 SolvedPosition => transform.position + relativePosition;

    /// <summary>
    /// Returns 4 corners of the center Y-Axis Slice
    /// 0 = Top Left
    /// 1 = Top Right
    /// 2 = Bottom Right
    /// 3 = Bottom Left
    /// </summary>
    public Vector2[] SolvedArea
    {
        get
        {
            var solved = SolvedPosition;
            return new[]
            {
                new Vector2(solved.x - (extents.x / 2), solved.z + (extents.z / 2)),
                new Vector2(solved.x + (extents.x / 2), solved.z + (extents.z / 2)),
                new Vector2(solved.x + (extents.x / 2), solved.z - (extents.z / 2)),
                new Vector2(solved.x - (extents.x / 2), solved.z - (extents.z / 2))
            };
        }
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.1f, 0.7f, 0.7f, 0.4f);
        Gizmos.DrawCube(SolvedPosition, extents);
        Handles.Label(SolvedPosition + Vector3.up * ((extents.y / 2) + 1), "OceanActiveArea");
    }
#endif
}
