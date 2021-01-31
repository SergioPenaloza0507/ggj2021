using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject player, enemy, diveSpot, instakill;
    private GameObject[] nmes, spots;
    
    // Start is called before the first frame update
    void Start()
    {
        nmes = new GameObject[5];
        spots = new GameObject[5];

        for (int i = 0; i < 5; i++)
        {
            nmes[i] = Instantiate(enemy);
            nmes[i].SetActive(false);
            spots[i] = Instantiate(diveSpot);
            spots[i].SetActive(false);
            spots[i].GetComponent<Clue>().ClueType = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNight()
    {
        for (int i = 0; i < 5;)
        {
            nmes[i].SetActive(true);
            nmes[i].transform.position = new Vector3(player.transform.position.x + Mathf.Floor(Random.Range(-80, 80)), 0, player.transform.position.z + Mathf.Floor(Random.Range(-80, 80)));
            spots[i].SetActive(true);
            spots[i].transform.position = new Vector3(player.transform.position.x + Mathf.Floor(Random.Range(-56, 56)), 0, player.transform.position.z + Mathf.Floor(Random.Range(-56, 56)));
            if (Vector3.Distance(player.transform.position, nmes[i].transform.position) > 32 && Vector3.Distance(player.transform.position, spots[i].transform.position) > 24)
            {
                i++;
            }
        }
    }

    public void StartDay()
    {
        for (int i = 0; i < 5; i++)
        {
            nmes[i].SetActive(false);
            spots[i].SetActive(false);
        }
    }
}