using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Section : MonoBehaviour
{
    public int minRequiredStops;
    public int placementNumber;
    public LaneShiftRules rule = LaneShiftRules.both;

    public enum LaneShiftRules
    {
        moveLeft, moveRight, both, neither
    }
}
