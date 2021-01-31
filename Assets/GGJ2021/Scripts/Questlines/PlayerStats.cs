using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int[] clues;
    [SerializeField] private UIManager UI;
    [SerializeField] int life, wood;

    public int Wood { get => wood; set => wood = value; }

    // Start is called before the first frame update
    void Start()
    {
        wood = 0;
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

    public void DiveUI(int type)
    {
        if(type == 5)
        {
            UI.DiveOpt(wood == 0);
        }
        if(type == 6)
        {
            UI.WinButt.SetActive(true);
        }
    }

    public void ButtsOff()
    {
        UI.RepairScreen.SetActive(false);
        UI.DiveButt.SetActive(false);
        UI.WinButt.SetActive(false);
    }

    public void Dive()
    {
        wood++;
        UI.Wood.SetActive(true);
        UI.DiveButt.SetActive(false);
    }

    public void RepairShip()
    {
        wood = 0;
        life++;
        UI.UpdateLifeBar(life);
        UI.Wood.SetActive(false);
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
