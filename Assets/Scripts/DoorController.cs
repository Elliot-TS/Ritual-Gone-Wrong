using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorOpen : MonoBehaviour
{
    //The Game Object 
    public GameObject door;
    public GameObject parent;

    //logic variables
    public float angleOpen;
    public float angleClose;
    public float speed;

    public bool opening;
    public bool check;


    void Update()
    {

        //Checking the trigger state, whether or not E is pressed
        opening = GameObject.Find("Player").GetComponent<PlayerController>().triggered;

        
        //Checking whether the player is looking at the object or not
        string objCheck = GameObject.Find("Player").GetComponent<PlayerController>().ObjectHit;

        if( (objCheck != null) && ( (objCheck.Equals(door.name)) || (objCheck.Equals(parent.name)) ) )
        {}

        else
        {
            return;
        }

        /*
        //Checking the distance from Player
        float objDist = GameObject.Find("Player").GetComponent<PlayerController>().objDistance;
        
        if(objDist > 2 || objDist < 0)
        {
            return;
        }*/


        Vector3 currentAngle = door.transform.localEulerAngles;

        if(opening && check)
        {
            if(angleOpen > angleClose)
            {
                if(Math.Abs(currentAngle.y) < Math.Abs(angleOpen))
                {
                    door.transform.localEulerAngles = Vector3.Lerp(currentAngle, new Vector3(currentAngle.x, angleOpen, currentAngle.z), speed * Time.deltaTime);
                }
            }

            else
            {
                if(Math.Abs(currentAngle.y) < Math.Abs(angleOpen))
                {
                    door.transform.localEulerAngles = Vector3.Lerp(currentAngle, new Vector3(currentAngle.x, angleOpen, currentAngle.z), speed * Time.deltaTime);
                }
            }
        }

        else if(!opening && check)
        {
            if(Math.Abs(currentAngle.y) > Math.Abs(angleClose))
            {
                door.transform.localEulerAngles = Vector3.Lerp(currentAngle, new Vector3(currentAngle.x, angleClose, currentAngle.z), speed * Time.deltaTime);
            }
        }
    }
}
