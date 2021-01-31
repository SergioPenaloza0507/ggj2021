using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int[] clues;
    [SerializeField] private UIManager UI;
    [SerializeField] int life, wood;
    GameObject spot;

    public int Wood { get => wood; set => wood = value; }

    // Start is called before the first frame update
    void Start()
    {
        wood = 7;
        clues = new int[4];
        for (int i = 0; i < 4; i++)
        {
            clues[i] = 0;
        }
        life = 3;
    }
    
    public void GetClue(int clue, int step)
    {
        if(clue < 4 && clues[clue] == step)
        {
            clues[clue]++;
            UI.NewHint(clue, clues[clue]);
            if (clues[clue] == 4)
            {
                //ActivateClueToEnd
            }
        }
        UI.RepairButt(wood != 0);
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

    public void RepairButtOff()
    {
        UI.RepairScreen.SetActive(false);
    }

    public void Dive()
    {
        wood++;
        spot.transform.position = new Vector3(Mathf.Round(Random.Range(1, 30.9f)) * 8, 3, Mathf.Round(Random.Range(1, 30.9f)) * 8);
        //UI button Dissapears
    }

    public void RepairShip()
    {
        wood = 0;
        life++;
        UI.UpdateLifeBar(life);
        UI.Wood.gameObject.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        if (amount > life)
            amount = life;
        life = life - amount;
        UI.UpdateLifeBar(life);
        if(life == 0)
        {
            //Game Over Screen
        }
    }
}
