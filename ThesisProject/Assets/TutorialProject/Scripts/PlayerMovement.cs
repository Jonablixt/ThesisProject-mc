using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody RB;
    private CameraSwitch CS;
    private Vector3 MovementInput;
    private Vector3 MovementVector;
    private Vector2 lastPosXZ;
    public float RunSpeed = 7;
    public float WalkSpeed = 5;
    public float CrouchSpeed = 3;
    public bool Moving = false;
    private bool canMove = false;
    public float JumpPower = 20;
    private bool jump;
    public bool isGrounded = true;
    public float maxSpeed = 10f;
    [SerializeField]
    private PlayerMoveMode moveMode;
    private Animator animator;

    private enum PlayerMoveMode
    {
        Walk,
        Sprint,
        Crouch
    }

    private Dictionary<PlayerMoveMode, float> moveSpeed = new Dictionary<PlayerMoveMode,float>();



    void Start()
    {
        moveSpeed.Add(PlayerMoveMode.Sprint, RunSpeed);
        moveSpeed.Add(PlayerMoveMode.Walk, WalkSpeed);
        moveSpeed.Add(PlayerMoveMode.Crouch, CrouchSpeed);

        RB = GetComponent<Rigidbody>();
        CS = GetComponent<CameraSwitch>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        ApplyMovement();
    }

    private void FixedUpdate()
    {
        if(canMove)
        RB.velocity += MovementVector * moveSpeed[moveMode] * Time.fixedDeltaTime;

        if(jump)
        {
            RB.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            jump = false;
        }
    }

    private void OnMovement(InputValue input)
    {
        if (input == null)
        {
            if(moveMode == PlayerMoveMode.Sprint)
            moveMode = PlayerMoveMode.Walk;
            return;
        }
        MovementInput = input.Get<Vector2>();

    }
    private void OnJump(InputValue input)
    {
        if (isGrounded)
        {
            jump = true;

        }
    }
    private void OnCrouch(InputValue input)
    {
        if (input == null) return;

        if (moveMode == PlayerMoveMode.Crouch)
        {
            moveMode = PlayerMoveMode.Walk;
        }
        else { moveMode = PlayerMoveMode.Crouch; }
    }
    private void OnCameraSwap(InputValue input)
    {
        if (input == null) return;
        CS.NextCamera();
        
    }
    private void OnSprint(InputValue input)
    {
        if (input == null) return;
        if (moveMode == PlayerMoveMode.Sprint)
        {
            moveMode = PlayerMoveMode.Walk;
        }
        else { moveMode = PlayerMoveMode.Sprint; }
    }
    private void ApplyMovement()
    {
        MovementVector = transform.right * MovementInput.x + transform.forward * MovementInput.y;

        Vector2 posXZ = new Vector2(transform.position.x, transform.position.z); // horizontal movement;

        if ((posXZ - lastPosXZ).magnitude < maxSpeed) // check moved distance from last frame.
            canMove = true;
        else canMove = false;

        Moving = !(posXZ == lastPosXZ);
        
        animator.SetBool("IsMoving", !(MovementInput.magnitude == 0f));
        lastPosXZ = new Vector2(transform.position.x, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null) return;
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision == null) return;
        isGrounded = false;
    }
}
