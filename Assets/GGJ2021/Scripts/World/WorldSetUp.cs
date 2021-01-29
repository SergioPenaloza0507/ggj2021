using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSetUp : MonoBehaviour
{
    [SerializeField] GameObject island, diveSpot, enemy;
    [SerializeField] float size;
    GameObject[] islands, dive, enemys;
    private GameObject treasure;

    // Start is called before the first frame update
    void Start()
    {
        islands = new GameObject[26];
        dive = new GameObject[20];
        for (int i = 0; i < 26; i++)
        {
            islands[i] = Instantiate(island);
            islands[i].transform.position = new Vector3(Mathf.Round(Random.Range(1, 30.9f)) * size, 3, Mathf.Round(Random.Range(1, 30.9f)) * size);
            if (i < 16)
            {
                islands[i].GetComponent<Clue>().ClueType = i / 4;
            }
            else
            {
                islands[i].GetComponent<Clue>().ClueType = 4;
            }
            if (i > 0)
            {
                for (int j = 0; j < i;)
                {
                    if (islands[i].transform.position == islands[j].transform.position)
                    {
                        islands[i].transform.position = new Vector3(Mathf.Round(Random.Range(1, 30.9f))*size, 3, Mathf.Round(Random.Range(1, 30.9f))*size);
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
            dive[i].GetComponent<Clue>().ClueType = 5;
            dive[i].transform.position = new Vector3(Mathf.Round(Random.Range(1, 30.9f))*size, 3, Mathf.Round(Random.Range(1, 30.9f))*size);
            for (int j = 0; j < 26;)
            {
                if (dive[i].transform.position == islands[j].transform.position)
                {
                    dive[i].transform.position = new Vector3(Mathf.Round(Random.Range(1, 30.9f)) * size, 3, Mathf.Round(Random.Range(1, 30.9f)) * size);
                    j = 0;
                }
                else
                    j++;
            }
        }

        treasure = Instantiate(diveSpot);
        treasure.GetComponent<Clue>().ClueType = 6;
        treasure.transform.position = new Vector3(Mathf.Round(Random.Range(1, 30.9f)) * size, 3, Mathf.Round(Random.Range(1, 30.9f)) * size);
        for (int i = 0; i < 26;)
        {
            if (islands[i].transform.position == treasure.transform.position)
            {
                treasure.transform.position = new Vector3(Mathf.Round(Random.Range(1, 30.9f)) * size, 3, Mathf.Round(Random.Range(1, 30.9f)) * size);
                i = 0; ;
            }
            else
                i++;
        }
        treasure.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
