using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ChestContentsHandler : MonoBehaviour
{
    [SerializeField] int num_glow_potions;
    [SerializeField] int num_fire_potions;
    [SerializeField] int num_transparency_potions;
    [SerializeField] int num_time_warp_potions;
    List<int> potions;
    List<int> old_potions;
    void Start()
    {
        potions = new List<int>() {num_glow_potions, num_fire_potions, num_transparency_potions, num_time_warp_potions};
        old_potions = new List<int>() { num_glow_potions, num_fire_potions, num_transparency_potions, num_time_warp_potions };
    }

    public List<int> Give_Chest_Contents()
    {
        return potions;
    }

    public void Display_Chest_Contents()
    {
        if (potions[0] != 0)
        {
            GameObject.FindWithTag("obtained item text").GetComponent<TMP_Text>().text = "Obtained " + potions[0] + "x glow potions";
        }
        if (potions[1] != 0)
        {
            if (potions[0] == 0)
            {
                GameObject.FindWithTag("obtained item text").GetComponent<TMP_Text>().text = "Obtained " + potions[1] + "x fire potions";
            }
            else
            {
                GameObject.FindWithTag("obtained item text").GetComponent<TMP_Text>().text += "<br>Obtained " + potions[1] + "x fire potions";
            }
        }
        if (potions[2] != 0)
        {
            if (potions[0] == 0 && potions[1] == 0)
            {
                GameObject.FindWithTag("obtained item text").GetComponent<TMP_Text>().text = "Obtained " + potions[2] + "x transparency potions";
            }
            else
            {
                GameObject.FindWithTag("obtained item text").GetComponent<TMP_Text>().text += "<br>Obtained " + potions[2] + "x transparency potions";
            }
        }
        if (potions[3] != 0)
        {
            if (potions[0] == 0 && potions[1] == 0 && potions[2] == 0)
            {
                GameObject.FindWithTag("obtained item text").GetComponent<TMP_Text>().text = "Obtained " + potions[3] + "x time warp potions";
            }
            else
            {
                GameObject.FindWithTag("obtained item text").GetComponent<TMP_Text>().text += "<br>Obtained " + potions[3] + "x time warp potions";
            }
        }
        StartCoroutine(Wait_Before_Reset());
    }

    IEnumerator Wait_Before_Reset()
    {
        yield return new WaitForSeconds(2.5f);
        GameObject.FindWithTag("obtained item text").GetComponent<TMP_Text>().text = "";
    }

    public void Empty_Chest()
    {
        num_fire_potions = 0;
        num_glow_potions = 0;
        num_time_warp_potions = 0;
        num_transparency_potions = 0;
        potions = new List<int>() { num_glow_potions, num_fire_potions, num_transparency_potions, num_time_warp_potions };
    }

    public void revert_potions()
    {
        potions = old_potions;
        num_glow_potions = old_potions[0];
        num_fire_potions = old_potions[1];
        num_transparency_potions = old_potions[2];
        num_time_warp_potions = old_potions[3];
    }
}
