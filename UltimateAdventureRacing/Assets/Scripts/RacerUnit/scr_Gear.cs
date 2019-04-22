using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Gear : MonoBehaviour
{
    public int[] lowerSpeeds;
    public int[] upperSpeeds;
    public int currentGear = 0;

    // Start is called before the first frame update
    void Start()
    {
        lowerSpeeds = new int[4];
        upperSpeeds = new int[4];

        lowerSpeeds[0] = 1;
        lowerSpeeds[1] = 2;
        lowerSpeeds[2] = 4;
        lowerSpeeds[3] = 6;

        upperSpeeds[0] = 3;
        upperSpeeds[1] = 5;
        upperSpeeds[2] = 8;
        upperSpeeds[3] = 12;
    }
    
    public void GearUp()
    {
        if (currentGear<3)
        {
            currentGear++;
        }
    }

    public void GearDown()
    {
        if (currentGear > 0)
        {
            currentGear--;
        }
    }

    public int GetUpperVal()
    {
        return upperSpeeds[currentGear];
    }

    public int GetLowerVal()
    {
        return lowerSpeeds[currentGear];
    }
}
