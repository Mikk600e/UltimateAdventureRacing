using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_GManager : MonoBehaviour
{
    public scr_RacerUnit[] units;
    [SerializeField]
    public scr_RacerUnit currentUnit;
    public int unitTracker = 0;
    public Text txt_remainingMovement;
    public Text txt_currentPlayer;
    public Button btn_GearUp;
    public Button btn_GearDown;

    // Start is called before the first frame update
    void Start()
    {
        //Sets up the first unit
        currentUnit = units[unitTracker];
        //Sets the randomizer seed based on the systems milliseconds
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }


    //Updates text on the UI
    void UpdateUI()
    {
        txt_remainingMovement.text = "Movement left: "+ currentUnit.remainingMovement;
        txt_currentPlayer.text = currentUnit.playerName + "'s turn";
    }

    void SwitchUnit()
    {
        currentUnit = units[unitTracker];
        if (unitTracker < units.Length - 1)
        {
            unitTracker++;
        }
        else
        {
            unitTracker = 0;
        }
    }

    //Method for when "End turn" button is clicked
    public void SetMovement()
    {
        if (currentUnit.remainingMovement == 0)
        {
            currentUnit.sectionStoppedCounter++;
            SwitchUnit();
            currentUnit.remainingMovement = UnityEngine.Random.Range(currentUnit.gearObject.GetLowerVal(), currentUnit.gearObject.GetUpperVal() + 1);
            currentUnit.startField = currentUnit.currentField;
            btn_GearDown.interactable = true;
            btn_GearUp.interactable = true;
        }
    }

    //Method for when "Gear up" is clicked
    public void GearUp()
    {
        currentUnit.gearObject.GearUp();
        btn_GearDown.interactable = false;
        btn_GearUp.interactable = false;
    }

    //Method for when "Gear down" is clicked
    public void GearDown()
    {
        currentUnit.gearObject.GearDown();
        btn_GearDown.interactable = false;
        btn_GearUp.interactable = false;
    }
}
