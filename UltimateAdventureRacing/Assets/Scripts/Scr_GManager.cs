using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_GManager : MonoBehaviour
{
    public scr_RacerUnit[] units;
    [SerializeField]
    scr_RacerUnit currentUnit;
    public int unitTracker = 0;
    public Text txt_remainingMovement;
    public Text txt_currentPlayer;

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

    public void SetMovement()
    {
        if (currentUnit.remainingMovement == 0)
        {
            SwitchUnit();
            currentUnit.remainingMovement = UnityEngine.Random.Range(1, currentUnit.speed + 1);
        }
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
}
