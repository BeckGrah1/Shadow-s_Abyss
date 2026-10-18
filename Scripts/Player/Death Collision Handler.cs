using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollisionHandler : MonoBehaviour
{
    GameObject player;
    bool playerIsDead = false;
    PlayerLightRaycast deathRaycast;
    CharacterMovement characterMovement;
    GameObject floorObject;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        deathRaycast = transform.GetChild(0).GetComponent<PlayerLightRaycast>();
        characterMovement = GameObject.FindWithTag("Player").GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerIsDead)
        {
            this.transform.position = player.transform.position;
        }
        else
        {
            this.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
            if (!Get_Shadow_Detection(deathRaycast))
            {
                characterMovement.restrictPlayerMovement(true);
            }
        }
    }

    bool Get_Shadow_Detection(PlayerLightRaycast PLR)
    {
        return PLR.Give_Player_Light_Raycast();
    }

    public void swapDeathBool(bool newValue)
    {
        playerIsDead = newValue;
        if (playerIsDead)
        {
            floorObject = GameObject.FindWithTag("floor parent object");
        }
    }
}
