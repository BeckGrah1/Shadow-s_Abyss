using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GiveItems : MonoBehaviour
{
    public List<int> chest_contents;
    public void Give_Item()
    {
        chest_contents = this.gameObject.GetComponent<ChestContentsHandler>().Give_Chest_Contents();
        GameObject.FindWithTag("Player").GetComponent<InventoryHandler>().Get_Potions(chest_contents);
    }
}
