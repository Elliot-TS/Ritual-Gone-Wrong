using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 prevMousePos;
    public float rotate_sensitivity = 0.1f;
    public float speed = 1f;

    //Trigger Check Variables
    public bool pressed = false;
    public bool triggered = false;

    //Raycast variables
    Ray ray;
    RaycastHit hit;
    public float maxDistance = 100f;
    public float objDistance = -1f;
    public string ObjectHit
    {
        get { return objectHit; }   // get method
        set { objectHit = value; }  // set method
    }
    private string objectHit;

    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray(transform.position, transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        //Trigger Check
        if (Input.GetKey(KeyCode.E))
        {
            pressed = true;
        }

        if(!Input.anyKey && pressed)
        {
            triggered = !triggered;
            pressed = false;
        }

        //Raycast Check
        ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            string hitName = hit.collider.gameObject.name;
            objDistance = hit.distance;
            
            if(!hitName.Equals(objectHit))
            {
                Debug.Log(hitName + " was hit from "+ objDistance + ".");
                objectHit = hitName;
            }
            
            else if(Input.anyKey)
            {
                Debug.Log(hitName + " was hit from "+ objDistance + ".");
            }
        }


        // WASD movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MovePlayer(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            MovePlayer(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MovePlayer(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MovePlayer(Vector3.right * speed * Time.deltaTime);
        }

        Vector2 mousePos = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            RotatePlayer(-(mousePos.x - prevMousePos.x)*rotate_sensitivity);
        }
        prevMousePos = mousePos;

    }

    void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction);
    }

    void RotatePlayer(float angle)
    {
        transform.Rotate(Vector3.up, angle);
    }
}
