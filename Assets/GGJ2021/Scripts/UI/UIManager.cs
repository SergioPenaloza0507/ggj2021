using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject hint, repairScreen, diveButt, Die, WinButt;
    [SerializeField] Text[] questLine;
    [SerializeField] Text wood, life;
    [SerializeField] PlayerStats stats;

    public GameObject RepairScreen { get => repairScreen; set => repairScreen = value; }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewHint(int questType, int clues)
    {
        hint.SetActive(true);
        hint.GetComponentInChildren<Text>().text = "You found a clue on the questline:\n\n" + (questType + 1).ToString() + "\n\nTry to find the other ones";
        questLine[questType].text = clues.ToString();
    }

    public void RepairButt(bool canRepair)
    {
        repairScreen.SetActive(true);
        if (canRepair)
        {
            repairScreen.GetComponent<Button>().interactable = true;
        }
        else
            repairScreen.GetComponent<Button>().interactable = false;
    }
}
