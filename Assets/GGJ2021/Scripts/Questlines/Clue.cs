using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{
    [SerializeField]private int clueType;

    public int ClueType { get => clueType; set => clueType = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (clueType < 5)
            {
                other.GetComponent<PlayerStats>().GetClue(clueType);
                if (clueType < 4)
                    clueType = 4;
            }
            else
                other.GetComponent<PlayerStats>().DiveUI(gameObject, clueType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(clueType > 4)
        {
            //Update PlayerUI so button dissapears if button is still active
        }
    }
}
