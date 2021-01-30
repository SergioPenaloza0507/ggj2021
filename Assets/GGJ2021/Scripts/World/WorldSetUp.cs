using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSetUp : MonoBehaviour
{
    [SerializeField] GameObject island, diveSpot, enemy;
    [SerializeField] float size, height;
    GameObject[] islands, dive, enemys;
    private GameObject treasure;

    // Start is called before the first frame update
    void Start()
    {
        islands = new GameObject[26];
        for (int i = 0; i < 26; i++)
        {
            if (i < island.transform.childCount)
            {
                islands[i] = island.transform.GetChild(i).gameObject;
                islands[i].GetComponent<Clue>().ClueType = i / 4;
                islands[i].GetComponent<Clue>().Step = i - (Mathf.FloorToInt(i / 4)) * 4;
            }
            else
            {
                islands[i] = Instantiate(islands[Random.Range(0, 15)]);
                islands[i].GetComponent<Clue>().ClueType = 4;
            }

            islands[i].transform.position = new Vector3(Mathf.Floor(Random.Range(1, 30.9f)) * size, height, Mathf.Floor(Random.Range(1, 30.9f)) * size);

            if (i > 0)
            {
                for (int j = 0; j < i;)
                {
                    if (islands[i].transform.position == islands[j].transform.position)
                    {
                        islands[i].transform.position = new Vector3(Mathf.Round(Random.Range(1, 30.9f)) * size, height, Mathf.Round(Random.Range(1, 30.9f)) * size);
                        j = 0;
                    }
                    else
                        j++;
                }
            }
        }
        
        treasure = Instantiate(diveSpot);
        treasure.GetComponent<Clue>().ClueType = 6;
        treasure.transform.position = new Vector3(Mathf.Round(Random.Range(1, 30.9f)) * size, 0, Mathf.Round(Random.Range(1, 30.9f)) * size);
        treasure.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
