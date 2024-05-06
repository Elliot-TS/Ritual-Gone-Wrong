using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Tutorial followed from:
    // https://www.youtube.com/watch?v=b1uoLBp2I1w

    // original code:


    private Vector2 prevMousePos;
    public float rotate_sensitivity = 0.8f;
    //public float speed = 1f;
    public float zoom_sensitivity = 0.8f;



    // // // // // // //

    public Input PlayerInput;
    public Transform PlayerCamera;
    public Rigidbody Body;
    public float Speed = 1f;
    public float Sensitivity;
    public float RotationSensitivity = 0.8f;
    public float ZoomSensitivity = 0.8f;
    public float JumpAcceleration;


    private Vector3 MovementInput;
    private Vector2 MouseInput;
    private float xRotation;
    private float yRotation;







    // Start is called before the first frame update
    void Start()
    {
        PlayerInput = GetComponent<Input>();
        PlayerCamera = GetComponent<Camera>().transform;
        Body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        MovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.forward * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.back * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(Vector3.left * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(Vector3.right * Speed * Time.deltaTime);
        }

        Vector2 mousePos = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            RotatePlayer(-(mousePos.x - prevMousePos.x) * rotate_sensitivity);
        }
        prevMousePos = mousePos;

        MovePlayer();
        MoveCamera();

    }

    void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction);

        // Vector3 movementVector = transform.TransformDirection(MovementInput) * Speed;
        // Body.velocity = new Vector3(movementVector.x, Body.velocity.y, movementVector.z);

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Body.AddForce(Vector3.up * JumpAcceleration, ForceMode.Impulse);
        // }
    }

    void RotatePlayer(float angle)
    {
        transform.Rotate(Vector3.up, angle);
    }

    void MovePlayer()
    {
        Vector3 movementVector = transform.TransformDirection(MovementInput) * Speed;
        Body.AddForce(new Vector3(movementVector.x, Body.velocity.y, movementVector.z));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Body.AddForce(Vector3.up * JumpAcceleration, ForceMode.Impulse);
        }

    }

    void MoveCamera()
    {
        xRotation -= MouseInput.y * RotationSensitivity;
        yRotation -= MouseInput.x * RotationSensitivity;

        transform.Rotate(0f, MouseInput.x * RotationSensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
