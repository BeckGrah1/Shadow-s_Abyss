using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    FirstPersonCamera firstPersonCamera;
    CharacterMovement characterMovement;
    PlayerInteraction playerInteraction;
    GlowPotion glowPotion;
    FirePotion firePotion;
    TransparencyPotion transparencyPotion;
    TimeWarpPotion timeWarpPotion;
    bool can_player_move = true;
    bool can_camera_move = true;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonCamera = GetComponent<FirstPersonCamera>();
        characterMovement = GetComponent<CharacterMovement>();
        playerInteraction = GetComponent<PlayerInteraction>();
        glowPotion = GetComponent<GlowPotion>();
        firePotion = GetComponent<FirePotion>();
        transparencyPotion = GetComponent<TransparencyPotion>();
        timeWarpPotion = GetComponent<TimeWarpPotion>();
    }

    // Update is called once per frame
    void Update()
    {
        if (can_player_move)
        {
            HandleMoveInput();
            HandlePotionInput();
        }
        else
        {
            characterMovement.AddMoveInput(0, 0);
        }
        if (can_camera_move)
        {
            HandleCameraInput();
        }
       HandleInteractionInput();
    }

    void HandleCameraInput()
    {
        firstPersonCamera.AddXAxisInput(Input.GetAxis("Mouse Y") * Time.deltaTime);
        firstPersonCamera.AddYAxisInput(Input.GetAxis("Mouse X") * Time.deltaTime);
    }

    void HandleMoveInput()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float rightInput = Input.GetAxis("Horizontal");

        characterMovement.AddMoveInput(forwardInput, rightInput);
    }

    void HandleInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerInteraction.TryInteract();
        }
    }

    void HandlePotionInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            glowPotion.Use_Glow_Potion();
            //print("1 pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            firePotion.Use_Fire_Potion();
            //print("2 pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transparencyPotion.Use_Transparency_Potion();
            //print("3 pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            timeWarpPotion.Use_Time_Warp_Potion();
            //print("4 pressed");
        }
    }

    public void Toggle_Movement()
    {
        can_player_move = !can_player_move;
    }

    public bool Return_Movement()
    {
        return can_player_move;
    }

    public void Toggle_Camera()
    {
        can_camera_move = !can_camera_move;
    }
}
