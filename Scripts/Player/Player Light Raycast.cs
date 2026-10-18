using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerLightRaycast : MonoBehaviour
{
    GameObject[] light_list;
    int count;
    LayerMask transparentLayer;
    Vector3 raycast_direction;
    GameObject sun;
    TimeWarpPotion time_warp_script;

    private void Start()
    {
        transparentLayer = ~LayerMask.GetMask("Trans Object", "Death Collision");
        time_warp_script = this.gameObject.transform.parent.GetComponent<TimeWarpPotion>();
    }
    public bool Give_Player_Light_Raycast()
    {
        count = 0;
        if (light_list.Length == 0)
        {
            return false;
        }
        for (int i = 0;  i < light_list.Length; i++)
        {
            if (light_list[i].layer == 8 && Physics.Linecast(transform.position, light_list[i].transform.position, transparentLayer))
            {
                count += 1;
            }
            else if (light_list[i].layer == 9)
            {
                sun = time_warp_script.Give_Sun();
                transform.eulerAngles  = new Vector3(sun.transform.eulerAngles.x + 180, sun.transform.eulerAngles.y, sun.transform.eulerAngles.z);
                if(Physics.Raycast(transform.position, transform.forward, 1000f))
                {
                    count += 1;
                }
            }
        }
        if (count == light_list.Length)
        {
            print("in shadow");
            return true;
        }
        else { return false; }
    }

    public void Send_Light_Amount(GameObject[] newList)
    {
        light_list = newList;
    }

}
