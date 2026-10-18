using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    CharacterController characterController;
    [SerializeField] Vector3 boxSize;
    LayerMask wall_mask;
    LayerMask ground_mask;
    bool groundedPlayer;
    Vector3 playerVelocity;
    public float moveSpeed = 5f;
    private Vector3 moveDirection;
    float jumpHeight = 8f;
    float gravityValue = -9.81f;
    ShadowDetectionHandler shadowScript;
    bool isMovementRestricted;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        wall_mask = LayerMask.GetMask("Walls");
        ground_mask = LayerMask.GetMask("Ground");
        shadowScript = GameObject.FindWithTag("shadow detection handler").GetComponent<ShadowDetectionHandler>();
    }

    // Update is called once per frame
    void Update()
    {

        moveDirection.Normalize();
        moveDirection.y = -1f;

        //if (Input.GetKey(KeyCode.LeftShift))
        //{
            //characterController.Move(moveDirection * (moveSpeed + 2) * Time.deltaTime);
        //}
        //else
        //{
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        //}
        
        Jump_Update();
    }

    void Jump_Update()
    {
        groundedPlayer = Standing_Check();
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && Ground_Check())
        {
            playerVelocity.y = jumpHeight;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    public void AddMoveInput(float forwardInput, float rightInput)
    {
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        if (isMovementRestricted)
        {
            forward = Vector3.zero;
            right = Vector3.zero;
        }

        moveDirection = (forwardInput * forward) + (rightInput * right);
    }

    public bool Standing_Check()
    {
        if(Physics.CheckBox(new Vector3(transform.position.x, transform.position.y - .96f, transform.position.z), boxSize, transform.rotation, ~wall_mask))
        {
            //print("true");
            return true;
        }
        //print("false");
        return false;
    }

    public bool Ground_Check()
    {
        if (Physics.CheckBox(new Vector3(transform.position.x, transform.position.y - .96f, transform.position.z), boxSize, transform.rotation, ground_mask) && (!shadowScript.Give_Shadow_Status() || shadowScript.Give_Glow_Status()))
        {
            //print("true");
            return true;
        }
        //print("false");
        return false;
    }

    public void restrictPlayerMovement(bool isRestricted)
    {
        isMovementRestricted = isRestricted;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y - .99f, transform.position.z), boxSize);
    }
}
