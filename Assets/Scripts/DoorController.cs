using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorOpen : MonoBehaviour
{
    public GameObject door;

    public float angleOpen;
    public float angleClose;
    public float speed;

    public bool opening;
    public bool check;

    void Update()
    {
        Vector3 currentAngle = door.transform.localEulerAngles;

        if(opening)
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

        else
        {
            if(Math.Abs(currentAngle.y) > Math.Abs(angleClose))
            {
                door.transform.localEulerAngles = Vector3.Lerp(currentAngle, new Vector3(currentAngle.x, angleClose, currentAngle.z), speed * Time.deltaTime);
            }
        }
    }
}
