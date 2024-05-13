using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    // Tutorial followed from:
    // https://www.youtube.com/watch?v=b1uoLBp2I1w

    // original code:
    public float rotate_sensitivity = 0.1f;
    //public float speed = 1f;
    public float zoom_sensitivity = 0.8f;


    // // // // // // //

    public Input PlayerInput;
    public GameObject PlayerCamera;
    public Rigidbody Body;
    public float Acceleration = 1f;
    public float MaxSpeed = 20f;

    public float Sensitivity;
    public float RotationSensitivity = 0.8f;
    public float ZoomSensitivity = 0.8f;
    public float JumpAcceleration;


    private Vector3 MovementInput;
    private Vector2 MouseInput;
    private Vector2 PointerLoc;
    private Vector3 prevMousePos;

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

        Vector3 amount = (Input.mousePosition - prevMousePos) * RotationSensitivity * Time.deltaTime;
        if (Input.GetMouseButton(0))
            MoveCamera(amount);
        prevMousePos = Input.mousePosition;

    }


    void MovePlayer()
    {
        Vector3 movementVector = transform.TransformDirection(MovementInput) * MaxSpeed * Time.deltaTime;
        Body.velocity = movementVector;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Body.AddForce(Vector3.up * JumpAcceleration, ForceMode.Impulse);
        }

    }

    void MoveCamera(Vector3 amount)
    {
        transform.Rotate(0f, -amount.x, 0f);
        PlayerCamera.transform.Rotate(amount.y, 0f, 0f);

        // transform.Rotate(0f, MouseInput.x * RotationSensitivity, 0f);
        // PlayerCamera.transform.localRotation = Quaternion.Euler(amount.y, 0f, 0f);
    }
}
