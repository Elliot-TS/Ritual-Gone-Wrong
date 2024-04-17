using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 prevMousePos;
    public float rotate_sensitivity = 0.1f;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // WASD movement
        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
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
