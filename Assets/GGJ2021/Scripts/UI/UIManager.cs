using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject hint, repairScreen, diveButt, Die, winButt, life, wood;
    private Image[] hearts;
    [SerializeField] Text[] questLine;
    [SerializeField] PlayerStats stats;

    public GameObject RepairScreen { get => repairScreen; set => repairScreen = value; }
    public GameObject Wood { get => wood; set => wood = value; }
    public GameObject WinButt { get => winButt; set => winButt = value; }
    public GameObject DiveButt { get => diveButt; set => diveButt = value; }

    // Start is called before the first frame update
    private void Start()
    {
        hearts = life.GetComponentsInChildren<Image>();
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

    public void UpdateLifeBar(int left)
    {
        for(int i = 0; i < 3; i++)
        {
            if (i < left)
                hearts[i].gameObject.SetActive(true);
            else
                hearts[i].gameObject.SetActive(false);
        }
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

    public void DiveOpt(bool canDive)
    {
        DiveButt.SetActive(true);
        if (canDive)
        {
            DiveButt.GetComponent<Button>().interactable = true;
        }
        else
            DiveButt.GetComponent<Button>().interactable = false;
    }
}
