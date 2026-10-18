using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryHandler : MonoBehaviour
{
    public int glow_potion_amount = 0;
    public int fire_potion_amount = 0;
    public int transparency_potion_amount = 0;
    public int time_warp_potion_amount = 0;
    [SerializeField] GameObject inventory_ui;

    public void Get_Potions(List<int> chest_potion_list)
    {
        glow_potion_amount += chest_potion_list[0];
        fire_potion_amount += chest_potion_list[1];
        transparency_potion_amount += chest_potion_list[2];
        time_warp_potion_amount += chest_potion_list[3];
        Inventory_UI_Handler();
    }

    public void Remove_Potion(string potion_name)
    {
       if (potion_name == "glow_potion_amount")
        {
            glow_potion_amount -= 1;
        }
       else if (potion_name == "fire_potion_amount")
        {
            fire_potion_amount -= 1;
        }
       else if (potion_name == "transparency_potion_amount")
        {
            transparency_potion_amount -= 1;
        }
       else if (potion_name == "time_warp_potion_amount")
        {
            time_warp_potion_amount -= 1;
        }
       Inventory_UI_Handler();

    }

    public int Check_Potion_Amount(string potion_name)
    {
        if (potion_name == "glow_potion_amount")
        {
            return glow_potion_amount;
        }
        else if (potion_name == "fire_potion_amount")
        {
            return fire_potion_amount;
        }
        else if (potion_name == "transparency_potion_amount")
        {
            return transparency_potion_amount;
        }
        else if (potion_name == "time_warp_potion_amount")
        {
            return time_warp_potion_amount;
        }
        else { return 0; }
    }

    private void Inventory_UI_Handler()
    {
        inventory_ui.GetComponent<TMP_Text>().text = "";
        if (glow_potion_amount > 0)
        {
            inventory_ui.GetComponent<TMP_Text>().text += "Press 1: Use Glow Potion (" + glow_potion_amount.ToString() + "x)";
        }
        if (fire_potion_amount > 0)
        {
            if (inventory_ui.GetComponent<TMP_Text>().text == "")
            {
                inventory_ui.GetComponent<TMP_Text>().text += " Press 2: Use Fire Potion (" + fire_potion_amount.ToString() + "x)";
            }
            else
            {
                inventory_ui.GetComponent<TMP_Text>().text += "<br>Press 2: Use Fire Potion (" + fire_potion_amount.ToString() + "x)";
            }


        }
        if (transparency_potion_amount > 0)
        {
            if (inventory_ui.GetComponent<TMP_Text>().text == "")
            {
                inventory_ui.GetComponent<TMP_Text>().text += "Press 3: Use Transparency Potion (" + transparency_potion_amount.ToString() + "x)";
            }
            else
            {
                inventory_ui.GetComponent<TMP_Text>().text += "<br>Press 3: Use Transparency Potion (" + transparency_potion_amount.ToString() + "x)";
            }    

        }
        if (time_warp_potion_amount > 0)
        {
            if (inventory_ui.GetComponent<TMP_Text>().text == "")
            {
                inventory_ui.GetComponent<TMP_Text>().text += "Press 4: Use Time Potion (" + time_warp_potion_amount.ToString() + "x)";
            }
            else
            {
                inventory_ui.GetComponent<TMP_Text>().text += "<br>Press 4: Use Time Potion (" + time_warp_potion_amount.ToString() + "x)";
            }

        }
    }

    public void Empty_Inventory()
    {
        glow_potion_amount = 0;
        fire_potion_amount = 0;
        transparency_potion_amount = 0;
        time_warp_potion_amount = 0;
        Inventory_UI_Handler();
    }
}
