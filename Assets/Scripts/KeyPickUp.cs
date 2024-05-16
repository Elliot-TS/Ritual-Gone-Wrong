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
        float dist = Vector3.Distance(GameObject.Find("Player").transform.position, this.transform.position);

        if(dist > 2.5 || dist <= 0)
            return;


        /*if (!LookCheck()) 
        {
            return;
        }*/

        GameObject.Find("Player").GetComponent<PlayerController>().pickedKey = true;
        Destroy(obj);

        Debug.Log("Clicked Key");
    }
}