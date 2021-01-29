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
            repairScreen.GetComponentInChildren<Button>().gameObject.SetActive(true);
            repairScreen.GetComponentInChildren<Text>().text = "Want to repair your ship?\n\nYou will lose 3 pieces of wood";
        }
        else
            repairScreen.GetComponentInChildren<Text>().text = "You don't have enough pieces of\nwood to repair your ship\n\nTry to find replacements under the sea";
    }
}
