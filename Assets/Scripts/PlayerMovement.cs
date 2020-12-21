using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;

    [Range(1, 10)]
    public float maxJumpHeight = 1;
    [Range(0, 100)]
    public float speed = 50;
    [Range(0, 1000)]
    public float mouseSensitivity = 0.5f;
    public float jumpDuration = 0.4f;
    public bool rawMovement = true;
    public Vector3 gravity;
    [HideInInspector]
    public Vector3 spawnPoint;

    float jumpStartTime = 0;
    float jump = 0;
    float jumpPrev = 0;
    bool frozen = false;
    bool jumping = false;
    PlayerControls controls;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        spawnPoint = this.transform.position;
        controls = gameObject.GetComponent<PlayerControls>();
    }

    public void Freeze()
    {
        frozen = true;
    }

    public void UnFreeze()
    {
        frozen = false;
    }

    void Update()
    {
        float h, v;

        if(rawMovement)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
        }
        else
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }

        bool requestJump = Input.GetKeyDown(controls.jumpKey);
        bool requestReset = Input.GetKeyDown(controls.resetKey);

        float mouseX = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime);

        if (requestJump && characterController.isGrounded)
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

        Vector3 movement = transform.forward * v + transform.right * h;

        if (requestReset)
        {
            //characterController.enabled = false;
            //characterController.transform.position = spawnPoint;
            //characterController.enabled = true;
            //Debug.Log("Respawning: " + spawnPoint.ToString());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if(frozen)
        {
            characterController.Move(Vector3.zero*Time.deltaTime * speed+gravity);
        }
        else
        {
            characterController.Move(movement.normalized * Time.deltaTime * speed + (jumping ? transform.up * (jump - jumpPrev) : gravity));
        }



        //Debug.Log("Horizontal: " + h + " Vertical: " + v + " Normalized: " + movement.normalized.ToString());
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.transform.CompareTag("Wall"))
        {
            // stop jumping if you hit the wall
            // should be done with raycasts, to block jumps that are too close to a wall
            jump = maxJumpHeight;
            jumping = false;
        }
    }
}
