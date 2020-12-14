using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;

    [Range(1, 10)]
    public float maxJumpHeight = 1;

    [Range(0, 100)]
    public float speed = 50;

    [Range(0, 100)]
    public float mouseAcceleration = 0.5f;

    public float jumpDuration = 0.4f;

    float jumpStartTime = 0;
    float jump = 0;
    float jumpPrev = 0;
    bool jumping = false;

    public Vector3 gravity;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        float mouseX = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up * mouseX * mouseAcceleration * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            jumpStartTime = Time.time;
            jumping = true;
        }

        jumpPrev = jump;
        jump = Mathf.SmoothStep(0, maxJumpHeight, (Time.time - jumpStartTime) / jumpDuration);

       
        if (jump >= maxJumpHeight)
        {
            jumpStartTime = Time.time;
            jumping = false;
        }

        characterController.Move((
            transform.forward * v  + 
            transform.right * h) * Time.deltaTime * speed
            + (jumping ? transform.up * (jump - jumpPrev) : gravity));
    }
}
