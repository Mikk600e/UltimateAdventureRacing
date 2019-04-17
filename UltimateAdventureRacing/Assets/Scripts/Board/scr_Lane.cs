using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Lane : MonoBehaviour
{
    public List<scr_Field> fields;
    // Start is called before the first frame update
    void Start()
    {
        //Adds every child to the list of fields (should probably validate whether the child is a field or not)
        foreach (Transform child in transform)
        {
            fields.Add(child.gameObject.GetComponent<scr_Field>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
