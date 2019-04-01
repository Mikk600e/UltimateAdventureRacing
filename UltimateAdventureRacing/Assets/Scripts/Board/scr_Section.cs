using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Section : MonoBehaviour
{
    public enum LaneShiftRules
    {
        moveLeft, moveRight, both, neither
    }

    public int minRequiredStops;
    public int placementNumber;
    public List<scr_Lane> lanes;
    public LaneShiftRules rule = LaneShiftRules.both;
    
    void Start()
    {
        foreach (Transform child in transform)
        {
            lanes.Add(child.gameObject.GetComponent<scr_Lane>());
        }
    }
}
