/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public GameObject obj;

    public bool picked = false;
    public bool check = false;

    void Start()
    {
    }


    void Update()
    {
        //Checking the trigger state, whether or not E is pressed
        check = GameObject.Find("Player").GetComponent<PlayerController>().triggered;

        string objCheck = GameObject.Find("Player").GetComponent<PlayerController>().ObjectHit;
        
        if( (objCheck != null) && (objCheck.Equals(obj.name)) )    
            {}
        else    
            return;


        float objDistance = GameObject.Find("Player").GetComponent<PlayerController>().objDistance;
        
        if( objDistance > 2.5 || objDistance < 0 )     
        {
            return;
        }

        GameObject.Find("Player").GetComponent<PlayerController>().pickedKey = true;
        Destroy(obj);

    }
}
*/