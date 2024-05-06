using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject obj;

    public bool check = false;
    private bool change = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        
        if(check)
        {
            /*move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            rotate = Input.GetAxis("Horizontal") * speed2 * Time.deltaTime;*/

            transform.SetParent(GameObject.Find("Player").transform, true);
        }

        else
            transform.SetParent(null, true);
    }

    /*private void LateUpdate()
    {
        transform.Translate(0f, 0f, move);
        transform.Translate(0f, rotate, 0f);
    }*/
}
