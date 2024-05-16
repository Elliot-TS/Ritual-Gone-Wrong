using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ChestController: MonoBehaviour, IPointerClickHandler
{
    public float AngleOpen = 0;
    public float AngleClose = 90;
    public float speed = 3;

    public bool IsOpen = false;
    private bool isOpenChange = false;

    private bool opening = false;
    private bool closing = false;

    private float triggerAngle;
    private float triggerTime;

    void Update()
    { 
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
        float interpolation = (Time.time - triggerTime) / speed;
        float angle = Mathf.Lerp(triggerAngle, AngleOpen, interpolation);
        transform.localEulerAngles = new Vector3(angle, 0, 0);
        if (interpolation >= 1) opening = false;
    }

    private void closeDoor() {
        float interpolation = (Time.time - triggerTime) / speed;
        float angle = Mathf.Lerp(triggerAngle, AngleClose, interpolation);
        transform.localEulerAngles = new Vector3(angle, 0, 0);
        if (interpolation >= 1) opening = false;
    }

    public void Open() {
        IsOpen = true;
        isOpenChange = IsOpen;
        opening = true;
        closing = false;
        triggerAngle = transform.localEulerAngles.x;
        triggerTime = Time.time;
        Debug.Log("Opening");
        Debug.Log(triggerAngle);
    }

    public void Close() {
        IsOpen = false;
        isOpenChange = IsOpen;
        opening = false;
        closing = true;
        //triggerAngle = transform.eulerAngles.x;
        triggerAngle = 200;
        triggerTime = Time.time;
        Debug.Log("Closing");
        Debug.Log(triggerAngle);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Get the player object and check if it has the key
        Debug.Log("Click");
        GameObject player = GameObject.Find("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController.pickedKey) {
            if (IsOpen) Close();
            else Open();
            Debug.Log("Click with key");
        }
    }
}
