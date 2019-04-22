using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_UnitFollower : MonoBehaviour
{
    public Scr_GManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(gameManager.currentUnit.transform.position.x,transform.position.y,gameManager.currentUnit.transform.position.z);
    }
}
