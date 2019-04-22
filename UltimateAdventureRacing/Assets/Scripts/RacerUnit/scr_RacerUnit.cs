using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_RacerUnit : MonoBehaviour
{
    public int turnOrder;
    public int remainingMovement = 0;
    public scr_Gear gearObject;
    public int speed;
    public scr_Field startField;
    public scr_Field currentField;
    public scr_Section currentSection;
    public bool isCrashed = false;
    public string playerName;
    public int currentLap = 1;
    public int sectionStoppedCounter;
    public int finishedInPlace;
    public bool isStillPlaying = true;

    public void Start()
    {
        gearObject = GetComponent<scr_Gear>();
        currentField = startField;
        speed = 8;
        transform.position = startField.transform.position;
    }

    private void Update()
    {
        if (isStillPlaying)
        {
            if (Input.GetMouseButtonDown(0) && remainingMovement > 0)
            {
                if (currentField.isSectionFinish && sectionStoppedCounter < currentSection.minRequiredStops)
                {
                    Crash();
                }
                else
                {
                    //sets the available fields. 
                    List<scr_Field> fields = PossibleFields();
                    MoveUnit();

                    //clear the "isPossible" bool of the fields, since after moving they are no longer possible
                    foreach (scr_Field field in fields)
                    {
                        field.isPossible = false;
                    }
                }
            }
        }

        else
        {
            remainingMovement = 0;
        }
    }

    private void Crash()
    {
        remainingMovement = 0;
        currentField = startField;
        transform.position = startField.gameObject.transform.position;
        currentSection = currentField.GetComponentInParent<scr_Section>();
    }

    public bool MoveUnit()
    {
        //Cast a ray to find the object clicked on
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            //store the hit game object's scr_Field
            scr_Field clickedField = hit.transform.gameObject.GetComponent<scr_Field>();
            if (clickedField.isPossible)
            {
                //Move unit and update current field if the clicked field was a valid field
                transform.position = hit.transform.position;
                currentField = clickedField;
                remainingMovement--;
            }
        }

        //Stops the player from being active. Currently at the end of lap, but should be changed
        if (currentField.isLapFinish)
        {
            isStillPlaying = false;
        }

        return true;
    }

    public List<scr_Field> PossibleFields() // uses currentField to evaluate possible movements
    {
        List<scr_Field> scr_Fields = new List<scr_Field>();
        if (!currentField.isSectionFinish)
            scr_Fields = PossibleFieldsSection();
        else 
        {
            scr_Fields = PossibleFieldsChangeSection();
        }

        return scr_Fields;
    }

    private List<scr_Field> PossibleFieldsChangeSection()
    {
        List<scr_Field> Fields = new List<scr_Field>();
        scr_Section nextSec = currentSection.nextSection;

        //Add the next field in middle lane
        scr_Field tempField = nextSec.lanes[currentField.lane].fields[0];
        if (LegitimateMove(tempField))
        {
            tempField.isPossible = true;
            Fields.Add(tempField);
        }

        //Add the next field in the lane to the right
        if (currentSection.rule == scr_Section.LaneShiftRules.both || currentSection.rule == scr_Section.LaneShiftRules.moveRight)
        {
            if (currentField.lane > 0)
            {
                tempField = nextSec.lanes[currentField.lane - 1].fields[0];
                if (LegitimateMove(tempField))
                {
                    tempField.isPossible = true;
                    Fields.Add(tempField);
                }
            }
        }

        //Add the next field in left lane
        if (currentSection.rule == scr_Section.LaneShiftRules.both || currentSection.rule == scr_Section.LaneShiftRules.moveLeft)
        {
            if (currentField.lane < currentSection.lanes.Count - 1)
            {
                tempField = nextSec.lanes[currentField.lane + 1].fields[0];
                if (LegitimateMove(tempField))
                {
                    tempField.isPossible = true;
                    Fields.Add(tempField);
                }
            }
        }

        currentSection = nextSec;
        sectionStoppedCounter = 0;
        return Fields;
    }

    List<scr_Field> PossibleFieldsSection()
    {
        List<scr_Field> Fields = new List<scr_Field>();

        //Add the next field in middle lane
        scr_Field tempField = currentSection.lanes[currentField.lane].fields[currentField.placementNumber + 1];
        if (LegitimateMove(tempField))
        {
            tempField.isPossible = true;
            Fields.Add(tempField);
        }

        //Add the next field in the lane to the right
        if (currentSection.rule == scr_Section.LaneShiftRules.both || currentSection.rule == scr_Section.LaneShiftRules.moveRight)
        {
            if (currentField.lane > 0)
            {
                tempField = currentSection.lanes[currentField.lane - 1].fields[currentField.placementNumber + 1];
                if (LegitimateMove(tempField))
                {
                    tempField.isPossible = true;
                    Fields.Add(tempField);
                }
            }
        }

        //Add the next field in left lane
        if (currentSection.rule == scr_Section.LaneShiftRules.both || currentSection.rule == scr_Section.LaneShiftRules.moveLeft)
        {
            if (currentField.lane < currentSection.lanes.Count - 1)
            {
                tempField = currentSection.lanes[currentField.lane + 1].fields[currentField.placementNumber + 1];
                if (LegitimateMove(tempField))
                {
                    tempField.isPossible = true;
                    Fields.Add(tempField);
                }
            }
        }

        return Fields;
    }

    // checks if field is viable and legitimate i.e. no other racers, it exists etc.
    public bool LegitimateMove(scr_Field possibleMove) 
    {
        return true;
    }
}
