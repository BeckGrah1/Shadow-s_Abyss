using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlowPotion : MonoBehaviour
{
    [SerializeField] GameObject player_glow_light;
    bool is_coroutine_running = false;
    bool can_player_glow = true;
    float glow_duration = 5f;
    public void Use_Glow_Potion()
    {
        if (this.gameObject.GetComponent<InventoryHandler>().Check_Potion_Amount("glow_potion_amount") > 0 && can_player_glow)
        {
            this.gameObject.GetComponent<InventoryHandler>().Remove_Potion("glow_potion_amount");
            player_glow_light.SetActive(true);
            GameObject.FindWithTag("shadow detection handler").GetComponent<ShadowDetectionHandler>().Toggle_Glow_Light();
            StartCoroutine(Wait_For_Potion_Use());
        }
        else if (is_coroutine_running == false && can_player_glow)
        {
            GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text = "You don't have any glow potions.";
            StartCoroutine(Wait_To_Reset());
        }

    }

    IEnumerator Wait_For_Potion_Use()
    {
        if (GameObject.FindWithTag("glow duration"))
        {
            yield return new WaitForSeconds(2f);
        }
        else
        {
            yield return new WaitForSeconds(glow_duration);
        }
        player_glow_light.SetActive(false);
        GameObject.FindWithTag("shadow detection handler").GetComponent<ShadowDetectionHandler>().Toggle_Glow_Light();
    }

    IEnumerator Wait_To_Reset()
    {
        is_coroutine_running = true;
        yield return new WaitForSeconds(2);
        if (GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text == "You don't have any glow potions.")
        {
            GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text = "";
        }
        is_coroutine_running = false;
    }

    public void Toggle_Glowability(bool glow)
    {
        can_player_glow = glow;
    }


}
