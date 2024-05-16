using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class MoveObject : MonoBehaviour, IPointerClickHandler
{
    public bool check = false;


    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        /*string objCheck = GameObject.Find("Player").GetComponent<PlayerController>().ObjectHit;
        
        if( (objCheck != null) && (objCheck.Equals(obj.name)) )    
            {}
        else    
            return;


        float objDistance = GameObject.Find("Player").GetComponent<PlayerController>().objDistance;
        
        if( objDistance > 2.5 || objDistance < 0 )     
        {
            return;
        }*/

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        float dist = Vector3.Distance(GameObject.Find("Player").transform.position, this.transform.position);

        if(dist > 2.5 || dist <= 0)
            return;

        check = !check;

        if(check)
        {
            this.transform.SetParent(GameObject.Find("Player").transform, true);
            Debug.Log("Picked up "+this.name);

            if(gameObject.GetComponent<Rigidbody>())
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
            
            float playerY = GameObject.Find("Player").transform.position.y;
            Vector3 currentPosition = transform.position;
            currentPosition.y = playerY;
            this.transform.position = currentPosition;
        }

        else
        {    
            this.transform.SetParent(null, true);
            Debug.Log("Dropped "+this.name);

            if(gameObject.GetComponent<Rigidbody>())
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
