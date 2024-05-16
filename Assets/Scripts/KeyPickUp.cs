using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class KeyPickUp : MonoBehaviour, IPointerClickHandler
{
    public GameObject obj;

    void Start()
    {
    }


    bool LookCheck()
    {
        string objCheck = GameObject.Find("Player").GetComponent<PlayerController>().ObjectHit;
        
        if( (objCheck != null) && (objCheck.Equals(obj.name)) )    
            return true;
        else    
            return false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        float objDistance = GameObject.Find("Player").GetComponent<PlayerController>().objDistance;
        
        /*if( objDistance > 2.5 || objDistance < 0 )     
        {
            return;
        }

        if (!LookCheck()) 
        {
            return;
        }*/

        GameObject.Find("Player").GetComponent<PlayerController>().pickedKey = true;
        Destroy(obj);

        Debug.Log("Clicked Key");
    }
}