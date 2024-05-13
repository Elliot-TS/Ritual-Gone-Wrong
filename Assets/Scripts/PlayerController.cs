using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    // Tutorial followed from:
    // https://www.youtube.com/watch?v=b1uoLBp2I1w

    // original code:


    public CharacterController CharCtrl;
    public float rotate_sensitivity = 0.8f;
    //public float speed = 1f;
    public float zoom_sensitivity = 0.8f;


    // // // // // // //

    public Input PlayerInput;
    public Transform PlayerCamera;
    public Rigidbody Body;
    public float Acceleration = 1f;
    public float MaxSpeed = 4f;

    public float Sensitivity;
    public float RotationSensitivity = 0.8f;
    public float ZoomSensitivity = 0.8f;
    public float JumpAcceleration;


    private Vector3 MovementInput;
    private Vector2 MouseInput;
    private Vector2 PointerLoc;
    private float xRotation;
    private float yRotation;



    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody>();
        Body.freezeRotation = true;
        PointerLoc = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {

        MovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();

        Vector2 mousePos = Input.mousePosition;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveCamera();
        }

    }


    void MovePlayer()
    {
        Vector3 movementVector = transform.TransformDirection(MovementInput) * Acceleration;
        Body.AddForce(new Vector3(movementVector.x, 0f, movementVector.z));
        Body.velocity = Vector3.ClampMagnitude(Body.velocity, MaxSpeed);


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

        transform.Rotate(0f, MouseInput.x * RotationSensitivity, 0f);
        //PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
