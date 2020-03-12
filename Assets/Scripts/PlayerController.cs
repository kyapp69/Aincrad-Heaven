using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float crouchHeight = 0.1f;

    public Transform groundCheck;

    public float groundDistance = 0.4f;
    public float roofDistance = 0.4f;

    public LayerMask groundMask;
    public LayerMask respawnMask;
    public LayerMask roofMask;

    bool isGrounded;
    bool isRespawn;
    bool isRoof;

    Vector3 velocity;

    CharacterController characterCollider;
    void Start ()
    {
        characterCollider = gameObject.GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isRespawn = Physics.CheckSphere(groundCheck.position, groundDistance, respawnMask);
        isRoof = Physics.CheckSphere(groundCheck.position, roofDistance, roofMask);

        if (isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        if(isRespawn && velocity.y <0)
        {
            Debug.Log("Ground touched");
            //Teleport to specified cords
        }

        if(isRoof && velocity.y <0)
        {
            Debug.Log("Roof touched");
            //Cannot crouch when roof is being touched
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftControl))
        {
            characterCollider.height = crouchHeight;
        }
        else
        {
            characterCollider.height = 2f;
        }
    }
}
