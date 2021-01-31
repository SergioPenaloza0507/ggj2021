using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    private static DayNight instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as DayNight;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public static DayNight Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject g = new GameObject($"{typeof(DayNight).Name} [Generated]");
                instance = g.AddComponent<DayNight>();
            }
            return instance;
        }
    }


    private static void DestroyAllNonInstances()
    {
        foreach (var go in FindObjectsOfType<DayNight>())
        {
            if (go != instance)
            {
                Destroy(go);
            }
        }
    }

    [SerializeField] private Material dayMat;
    [SerializeField] private Material night;
    [SerializeField] private Material skyBox;

    bool isDay;

    

    [SerializeField] private float dayTime;
    [SerializeField] private float nightTime;

    public bool IsDay { get => isDay; set => isDay = value; }

    // Use this for initialization
    void Start()
    {
        skyBox = RenderSettings.skybox;
        dayMat = new Material(skyBox);
        isDay = false;
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Timer()
    {
        if(isDay)
        {
            RenderSettings.skybox = dayMat;
            yield return new WaitForSecondsRealtime(dayTime);
        }

        else
        {
            RenderSettings.skybox = night;
            yield return new WaitForSecondsRealtime(nightTime);
        }

        isDay = !isDay;
        StartCoroutine("Timer");
    }
}
