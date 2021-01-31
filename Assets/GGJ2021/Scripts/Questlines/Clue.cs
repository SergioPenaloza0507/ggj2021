using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{
    [SerializeField]private int clueType;
    private int step;

    public int ClueType { get => clueType; set => clueType = value; }
    public int Step { get => step; set => step = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (DayNight.Instance.IsDay && other.tag == "Player")
        {
            if (clueType < 5)
            {
                other.GetComponent<PlayerStats>().GetClue(clueType, step);
            }
            else
                other.GetComponent<PlayerStats>().DiveUI(gameObject, clueType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().RepairButtOff();
        }
    }
}
