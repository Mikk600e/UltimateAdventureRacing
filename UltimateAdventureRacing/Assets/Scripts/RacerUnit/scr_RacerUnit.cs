using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_RacerUnit : MonoBehaviour
{
    public int turnOrder;
    public int remainingMovement = 0;
    public scr_Gear gearObject;
    public int currentGear = 1;
    public scr_Field startField;
    public scr_Field currentField;
    public bool isCrashed = false;
    public string playerName;
    public int currentLap = 1;
    public int sectionStoppedCounter;
    public int finishedInPlace;
    public bool isStillPlaying = true;

    public void Start()
    {
        
    }

    public bool MoveUnit()
    {

        return true;
    }

    public scr_Field[] PossibleFields() // uses currentField to evaluate possible movements
    {
        scr_Field[] scr_Fields = new scr_Field[3];

        return scr_Fields;
    }

    public bool LegitimateMove(scr_Field possibleMove) // checks if field is viable and legitimate i.e. no other racers, it exits etc.
    {
        return true;
    }




}
