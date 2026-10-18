using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<LightTracker>().Change_Light_List();
        GameObject.FindWithTag("Player").GetComponent<TimeWarpPotion>().Reset_Sun_Trigger();
        if (GameObject.FindWithTag("sun finder"))
        {
            GameObject.FindWithTag("Player").GetComponent<TimeWarpPotion>().Sun_Change();
        }
        GameObject.FindWithTag("Player").GetComponent<InventoryHandler>().Empty_Inventory();
        GameObject.FindWithTag("Player").GetComponent<PlayerInteraction>().Reset_Torches();
        GameObject.FindWithTag("Player").GetComponent<PlayerInteraction>().Reset_Transparent_Objects();
    }
}
