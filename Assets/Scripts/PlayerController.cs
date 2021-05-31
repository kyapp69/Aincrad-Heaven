using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float crouchHeight = 0.1f;
    public float XX = 0.5620441f;
    public float YY = 1;
    public float ZZ = -800;

    public Transform groundCheck;
    public Transform roofCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;
    public LayerMask respawnMask;
    public LayerMask Level2Mask;
    public LayerMask Level3Mask;
    public LayerMask RoofMask;

    bool isGrounded;
    bool isRespawn;
    bool isLevel2;
    bool isLevel3;
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
        LoadChecks();
        ChecksUpdate();
        MoveUpdate();
        JumpUpdate();
        CrouchUpdate();
    }
    private void LoadChecks()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isRespawn = Physics.CheckSphere(groundCheck.position, groundDistance, respawnMask);
        isLevel2 = Physics.CheckSphere(groundCheck.position, groundDistance, Level2Mask);
        isLevel3 = Physics.CheckSphere(groundCheck.position, groundDistance, Level3Mask);
        isRoof = Physics.CheckSphere(roofCheck.position, groundDistance, RoofMask);
    }

    private void ChecksUpdate()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isRespawn && velocity.y < 0)
        {
            TeleportToTheTop();
        }

        if (isRoof && velocity.y < 0)
        {
            characterCollider.height = crouchHeight;
        }

        if (isLevel2 && velocity.y < 0)
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }

        if (isLevel3 && velocity.y < 0)
        {
            SceneManager.LoadScene("Ending", LoadSceneMode.Single);
            //Sorry...
        }
    }

    private void TeleportToTheTop()
    {
        transform.position = new Vector3(XX, YY, ZZ);
        Vector3 newPos = new Vector3(XX, YY, ZZ);
        transform.parent.position = newPos;
    }

    private void CrouchUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            characterCollider.height = crouchHeight;
        }
        else
        {
            characterCollider.height = 2f;
        }
    }

    private void JumpUpdate()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void MoveUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}
