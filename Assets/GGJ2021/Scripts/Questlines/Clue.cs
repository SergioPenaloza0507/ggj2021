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
        if (other.tag == "Player")
        {
            if (clueType < 5)
            {
                other.GetComponent<PlayerStats>().GetClue(clueType, step);
                StartCoroutine("WaitToActivate");
            }
            else
                other.GetComponent<PlayerStats>().DiveUI(gameObject, clueType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && clueType > 3)
        {
            other.GetComponent<PlayerStats>().RepairButtOff();
        }
    }

    private IEnumerator WaitToActivate()
    {
        yield return new WaitForSecondsRealtime(5);
    }
}
