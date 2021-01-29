using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]private int[] clues;
    int life, wood;
    GameObject spot;

    public int Wood { get => wood; set => wood = value; }

    // Start is called before the first frame update
    void Start()
    {
        clues = new int[4];
        for (int i = 0; i < 4; i++)
        {
            clues[i] = 0;
        }
        life = 3;
    }
    
    public void GetClue(int clue)
    {
        if(clue < 4)
        {
            //UI about clue and pause game
            clues[clue]++;
            if (clues[clue] == 4)
            {
                //ActivateClueToEnd
            }
        }
        else
        {
            //UI to RepairShip
        }
    }

    public void DiveUI(GameObject diveSpot, int type)
    {
        if(type == 5)
        {
            spot = diveSpot;
            //UI button asking if player wants to dive
        }
        if(type == 6)
        {
            //UI button asking if player wants to dive, but if they do it leads to win screen
        }
    }

    public void Dive()
    {
        wood++;
        spot.transform.position = new Vector3(Mathf.Round(Random.Range(1, 30.9f)) * 8, 3, Mathf.Round(Random.Range(1, 30.9f)) * 8);
        //UI button Dissapears
    }

    public void RepairShip()
    {
        if(wood > 3)
        {
            wood = wood - 3;
            life = 3;
        }
    }

    public void TakeDamage(int amount)
    {
        if (amount > life)
            amount = life;
        life = life - amount;
        if(life == 0)
        {
            //Game Over Screen
        }
    }
}
