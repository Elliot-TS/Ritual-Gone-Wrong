using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorOpen : MonoBehaviour, IPointerClickHandler
{
    public float AngleOpen = 0;
    public float AngleClose = 90;
    public float speed = 3;

    public bool IsOpen = false;
    private bool isOpenChange = false;

    private bool opening = false;
    private bool closing = false;


    void Update()
    { 

        /*float objDist = GameObject.Find("Player").GetComponent<PlayerController>().objDistance;
        
        if(objDist > 2 || objDist < 0)
        {
            return;
        }*/
        
        if (isOpenChange != IsOpen) 
        {
            if (IsOpen) Open();
            else Close();
        }
        isOpenChange = IsOpen;

        if (opening) {
            openDoor();
        }
        else if (closing) {
            closeDoor();
        }
    }

    private void openDoor() {
        Vector3 currentAngle = transform.localEulerAngles;
        transform.localEulerAngles = Vector3.Lerp(currentAngle, new Vector3(currentAngle.x, AngleOpen, currentAngle.z), speed * Time.deltaTime);
        if (Math.Abs(currentAngle.y - AngleOpen) < 0.01) opening = false;
    }

    private void closeDoor() {
        Vector3 currentAngle = transform.localEulerAngles;
        transform.localEulerAngles = Vector3.Lerp(currentAngle, new Vector3(currentAngle.x, AngleClose, currentAngle.z), speed * Time.deltaTime);
        if (Math.Abs(currentAngle.y - AngleClose) < 0.01) closing = false;
    }

    public void Open() {
        IsOpen = true;
        isOpenChange = IsOpen;
        opening = true;
        closing = false;
        Debug.Log("Opening");
    }

    public void Close() {
        IsOpen = false;
        isOpenChange = IsOpen;
        opening = false;
        closing = true;
        Debug.Log("Closing");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsOpen) Close();
        else Open();
        Debug.Log("Click");
    }
}
