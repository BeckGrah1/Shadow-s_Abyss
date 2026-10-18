using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TransparencyPotion : MonoBehaviour
{
    bool is_coroutine_running = false;
    public void Use_Transparency_Potion()
    {
        if (this.gameObject.GetComponent<InventoryHandler>().Check_Potion_Amount("transparency_potion_amount") > 0 && this.gameObject.GetComponent<PlayerInteraction>().Transparency_Check())
        {
            this.gameObject.GetComponent<InventoryHandler>().Remove_Potion("transparency_potion_amount");
        }
        else if (this.gameObject.GetComponent<InventoryHandler>().Check_Potion_Amount("transparency_potion_amount") == 0 && is_coroutine_running == false)
        {
            GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text = "You don't have any transparency potions.";
            StartCoroutine(Wait_To_Reset());
        }
        else if (!this.gameObject.GetComponent<PlayerInteraction>().Transparency_Check() && !is_coroutine_running)
        {
            GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text = "You aren't looking at a useable object.";
            StartCoroutine(Wait_To_Reset());
        }
    }

    IEnumerator Wait_To_Reset()
    {
        is_coroutine_running = true;
        yield return new WaitForSeconds(2);
        if ((GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text == "You don't have any transparency potions.") || (GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text == "You aren't looking at a useable object."))
        {
            GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text = "";
        }
        is_coroutine_running = false;
    }
}
