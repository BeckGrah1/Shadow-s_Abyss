using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShadowDetectionHandler : MonoBehaviour
{
    [SerializeField] PlayerLightRaycast PLR_Left;
    [SerializeField] PlayerLightRaycast PLR_Right;
    [SerializeField] PlayerLightRaycast PLR_Front;
    [SerializeField] PlayerLightRaycast PLR_Back;
    [SerializeField] GameObject death_screen;
    CharacterController characterController;
    CharacterMovement characterMovement;
    public bool glow_light_on = false;
    public LayerMask all_layers = ~0;
    DeathCollisionHandler deathCollisionHandler;

    private void Start()
    {
        characterController = transform.parent.GetComponent<CharacterController>();
        characterMovement = transform.parent.GetComponent<CharacterMovement>();
        deathCollisionHandler = GameObject.FindWithTag("death collision handler").GetComponent<DeathCollisionHandler>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Get_Shadow_Detection(PLR_Left) && Get_Shadow_Detection(PLR_Right) && Get_Shadow_Detection(PLR_Front) && Get_Shadow_Detection(PLR_Back) && !glow_light_on && characterMovement.Standing_Check())
        {
            Reset_Player();
        }
    }

    bool Get_Shadow_Detection(PlayerLightRaycast PLR)
    {
        return PLR.Give_Player_Light_Raycast();
    }

    void Reset_Player()
    {
        deathCollisionHandler.swapDeathBool(true);
        StartCoroutine(Wait_2_Sec());
        this.gameObject.transform.parent.GetComponent<CharacterController>().excludeLayers = all_layers;
        this.gameObject.transform.parent.GetComponent<GlowPotion>().Toggle_Glowability(false);
    }

    public void Toggle_Glow_Light()
    {
        glow_light_on = !glow_light_on;
    }

    public IEnumerator Wait_2_Sec()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.transform.parent.GetComponent<CharacterController>().excludeLayers = ~all_layers;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("chest").Length; i++)
        {
            print("code_ran");
            GameObject.FindGameObjectsWithTag("chest")[i].GetComponent<ChestContentsHandler>().revert_potions();
            GameObject.FindGameObjectsWithTag("chest")[i].GetComponent<InteractionObject>().Revert_Interaction_Text();
        }
        this.transform.parent.gameObject.GetComponent<PlayerInteraction>().Reset_Transparent_Objects();
        this.transform.parent.gameObject.GetComponent<PlayerInteraction>().Reset_Torches();
        this.transform.parent.gameObject.GetComponent<InventoryHandler>().Empty_Inventory();
        this.gameObject.transform.parent.GetComponent<GlowPotion>().Toggle_Glowability(true);
        this.transform.parent.gameObject.GetComponent<TimeWarpPotion>().Reset_Sun();
        GameObject.FindWithTag("Player").GetComponent<CharacterController>().enabled = false;
        GameObject.FindWithTag("Player").GetComponent<CharacterController>().transform.position = GameObject.FindWithTag("respawn").transform.position;
        GameObject.FindWithTag("Player").GetComponent<CharacterController>().enabled = true;
        deathCollisionHandler.swapDeathBool(false);
        characterMovement.restrictPlayerMovement(false);
    }

    public bool Give_Shadow_Status()
    {
        if (Get_Shadow_Detection(PLR_Left) && Get_Shadow_Detection(PLR_Right) && Get_Shadow_Detection(PLR_Front) && Get_Shadow_Detection(PLR_Back))
        {
            return true;
        }
        return false;
    }

    public bool Give_Glow_Status()
    {
        return glow_light_on;
    }
}
