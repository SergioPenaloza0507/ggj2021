using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSetUp : MonoBehaviour
{
    [SerializeField] GameObject island, diveSpot, enemy;
    [SerializeField] float size;
    GameObject[] islands, dive, enemys;

    // Start is called before the first frame update
    void Start()
    {
        islands = new GameObject[26];
        dive = new GameObject[20];
        for (int i = 0; i < 26; i++)
        {
            islands[i] = Instantiate(island);
            if (i < 16)
            {
                //islands[i].GetComponent<Clue>.clueType = i/4;
                islands[i].transform.position = new Vector3(Random.Range(0, 20)*size, 0, Random.Range(0, 20)*size);
            }
            else
            {
                //islands[i].GetComponent<Clue>.clueType = 4;
            }
            if (i > 0)
            {
                for (int j = 0; j < i;)
                {
                    if (islands[i].transform.position == islands[j].transform.position)
                    {
                        islands[i].transform.position = new Vector3(Random.Range(0, 20)*size, 0, Random.Range(0, 20)*size);
                        j = 0;
                    }
                    else
                        j++;
                }
            }
        }

        for (int i = 0; i<20;i++)
        {
            dive[i] = Instantiate(diveSpot);
            dive[i].transform.position = new Vector3(Random.Range(0, 20), -10, Random.Range(0, 20));
            if (i > 0)
            {
                for (int j = 0; j < i;)
                {
                    if (dive[i].transform.position == dive[j].transform.position)
                    {
                        dive[i].transform.position = new Vector3(Random.Range(0, 20), -10, Random.Range(0, 20));
                        j = 0;
                    }
                    else
                        j++;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
