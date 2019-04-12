﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_RacerUnit : MonoBehaviour
{
    public int turnOrder;
    public int remainingMovement = 0;
    public scr_Gear gearObject;
    public int currentGear = 1;
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
        speed = 8;
        transform.position = startField.transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && remainingMovement>0)
        {
            //sets the available fields. should be moved somewhere else, like the start of the racers turn instead of whenever clicking
            List<scr_Field> fields = PossibleFields();
            MoveUnit();

            //clear the "isPossible" bool of the fields, since after moving they are no longer possible
            foreach (scr_Field field in fields)
            {
                field.isPossible = false;
            }
        }
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
        return true;
    }

    public List<scr_Field> PossibleFields() // uses currentField to evaluate possible movements
    {
        List<scr_Field> scr_Fields = new List<scr_Field>();
        if (!currentField.isSectionFinish)
            scr_Fields = PossibleFieldsSection();

        return scr_Fields;
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
        if (currentField.lane > 0)
        {
            tempField = currentSection.lanes[currentField.lane - 1].fields[currentField.placementNumber + 1];
            if (LegitimateMove(tempField))
            {
                tempField.isPossible = true;
                Fields.Add(tempField);
            }
        }

        //Add the next field in left lane
        if (currentField.lane < currentSection.lanes.Count - 1)
        {
            tempField = currentSection.lanes[currentField.lane + 1].fields[currentField.placementNumber + 1];
            if (LegitimateMove(tempField))
            {
                tempField.isPossible = true;
                Fields.Add(tempField);
            }
        }

        return Fields;
    }

    public bool LegitimateMove(scr_Field possibleMove) // checks if field is viable and legitimate i.e. no other racers, it exits etc.
    {
        return true;
    }




}
