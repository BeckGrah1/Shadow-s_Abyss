using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LightTracker : MonoBehaviour
{
    
    public GameObject[] lights_list;

    private void Start()
    {
        lights_list = GameObject.FindGameObjectsWithTag("light source");
        this.gameObject.transform.Find("Shadow Detection (Right)").gameObject.GetComponent<PlayerLightRaycast>().Send_Light_Amount(lights_list);
        this.gameObject.transform.Find("Shadow Detection (Left)").gameObject.GetComponent<PlayerLightRaycast>().Send_Light_Amount(lights_list);
        this.gameObject.transform.Find("Shadow Detection (Front)").gameObject.GetComponent<PlayerLightRaycast>().Send_Light_Amount(lights_list);
        this.gameObject.transform.Find("Shadow Detection (Back)").gameObject.GetComponent<PlayerLightRaycast>().Send_Light_Amount(lights_list);
        GameObject.FindWithTag("death collision handler").GetComponentInChildren<PlayerLightRaycast>().Send_Light_Amount(lights_list);
    }

    public void Change_Light_List()
    {
        lights_list = GameObject.FindGameObjectsWithTag("light source");
        this.gameObject.transform.Find("Shadow Detection (Right)").gameObject.GetComponent<PlayerLightRaycast>().Send_Light_Amount(lights_list);
        this.gameObject.transform.Find("Shadow Detection (Left)").gameObject.GetComponent<PlayerLightRaycast>().Send_Light_Amount(lights_list);
        this.gameObject.transform.Find("Shadow Detection (Front)").gameObject.GetComponent<PlayerLightRaycast>().Send_Light_Amount(lights_list);
        this.gameObject.transform.Find("Shadow Detection (Back)").gameObject.GetComponent<PlayerLightRaycast>().Send_Light_Amount(lights_list);
        GameObject.FindWithTag("death collision handler").GetComponentInChildren<PlayerLightRaycast>().Send_Light_Amount(lights_list);
        print("light list count:" + lights_list.Length.ToString());
    }

}
