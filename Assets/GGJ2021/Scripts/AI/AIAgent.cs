using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{
    [SerializeField] float forwardInterval;
    [SerializeField] SingleParentNode composite;

    float timer;

    [SerializeField] GameObject roammingTracker;

    BhForwardedData data;

    private void Awake()
    {
        data = new BhForwardedData();
        data.SetValue("RoamingTracker", roammingTracker);
        roammingTracker.transform.parent = null;
    }

    private void Update()
    {
        if (!GameController.Instance.paused)
        {
            timer += Time.deltaTime;
            if(timer >= forwardInterval)
            {
                composite.Execute(data);
                timer = 0;
            }
        }
    }
}
