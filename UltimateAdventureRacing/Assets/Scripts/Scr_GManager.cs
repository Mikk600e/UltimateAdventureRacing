using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GManager : MonoBehaviour
{
    public scr_RacerUnit[] units;
    [SerializeField]
    scr_RacerUnit currentUnit;
    public int unitTracker = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentUnit = units[0];
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    }

    private void ExecuteTurn()
    {
        currentUnit.remainingMovement = UnityEngine.Random.Range(1, currentUnit.speed+1);        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentUnit.remainingMovement == 0)
        {
            currentUnit = units[unitTracker];
            ExecuteTurn();
            if (unitTracker < units.Length-1)
            {
                unitTracker++;
            }
            else
            {
                unitTracker = 0;
            }
        }
    }


}
