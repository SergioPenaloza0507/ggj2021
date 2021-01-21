using UnityEngine;

[DisallowMultipleComponent]
public abstract class MonoBehabiourSingleton<TThis> : MonoBehaviour where TThis : MonoBehaviour
{
    private static TThis instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this as TThis;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }

    public static TThis Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject g = new GameObject($"{typeof(TThis).Name} [Generated]");
                instance = g.AddComponent<TThis>();
            }
            return instance;
        }
    }

    private static void DestroyAllNonInstances()
    {
        foreach (var go in FindObjectsOfType<TThis>())
        {
            if(go != instance)
            {
                Destroy(go);
            }
        }
    }
}
