using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Public fields for Unity editor
    public CharacterController controller;
    public float defaultSpeed = 12f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Transform camera;
    public Transform standingCam;
    public Transform crouchingCam;

    public float gravityModifier = 1f;

    Vector3 velocity;
    float gravity = -9.81f;
    float crouchSpeed;
    float speed;
    bool isGrounded;
    bool isCrouching = false;

    void Start()
    {
        crouchSpeed = defaultSpeed / 3;
        speed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Crouching haha lmao
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching;
            speed = isCrouching ? crouchSpeed : defaultSpeed;
            camera.position = isCrouching ? crouchingCam.position : standingCam.position;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x) + (transform.forward * z);

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += (gravity * gravityModifier) * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
