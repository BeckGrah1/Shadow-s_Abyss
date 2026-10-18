using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirePotion : MonoBehaviour
{
    bool is_coroutine_running = false;
    public void Use_Fire_Potion()
    {
        if (this.gameObject.GetComponent<InventoryHandler>().Check_Potion_Amount("fire_potion_amount") > 0 && this.gameObject.GetComponent<PlayerInteraction>().Torch_Check())
        {
            this.gameObject.GetComponent<InventoryHandler>().Remove_Potion("fire_potion_amount");
        }

        else if(this.gameObject.GetComponent<InventoryHandler>().Check_Potion_Amount("fire_potion_amount") == 0 && is_coroutine_running == false)
        {
            GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text = "You don't have any fire potions.";
            StartCoroutine(Wait_To_Reset());
        }
        else if(!is_coroutine_running && !this.gameObject.GetComponent<PlayerInteraction>().Torch_Check())
        {
            GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text = "You aren't looking at a lightable torch.";
            StartCoroutine(Wait_To_Reset());
        }
    }

    IEnumerator Wait_To_Reset()
    {
        is_coroutine_running = true;
        yield return new WaitForSeconds(2);
        if ((GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text == "You don't have any fire potions.") || (GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text == "You aren't looking at a lightable torch."))
        {
            GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text = "";
        }
        is_coroutine_running = false;
    }
}
