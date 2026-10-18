using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TimeWarpPotion : MonoBehaviour
{
    GameObject sun = null;
    GameObject new_sun_location;
    public float desired_duration = 4f;
    bool sun_already_moved = false;
    Vector3 original_sun_location;
    float elapsed_time;
    float opposite_rotation;
    bool is_coroutine_running = false;
    public void Use_Time_Warp_Potion()
    {
        if (this.gameObject.GetComponent<InventoryHandler>().Check_Potion_Amount("time_warp_potion_amount") > 0 && GameObject.FindWithTag("sun finder").transform.parent.gameObject)
        {
            this.gameObject.GetComponent<InventoryHandler>().Remove_Potion("time_warp_potion_amount");
            Move_Sun();
        }
        else if (this.gameObject.GetComponent<InventoryHandler>().Check_Potion_Amount("time_warp_potion_amount") == 0 && !is_coroutine_running)
        {
            GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text = "You don't have any time warp potions.";
            StartCoroutine(Wait_To_Reset());
        }

    }

    IEnumerator Wait_To_Reset()
    {
        is_coroutine_running = true;
        yield return new WaitForSeconds(2);
        if ((GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text == "You don't have any time warp potions."))
        {
            GameObject.FindWithTag("potion problem text").GetComponent<TMP_Text>().text = "";
        }
        is_coroutine_running = false;
    }

    public void Move_Sun()
    {
        sun = GameObject.FindWithTag("sun finder").transform.parent.gameObject;
        new_sun_location = GameObject.FindWithTag("new sun location");
        original_sun_location = sun.transform.position;
        opposite_rotation = -135;
    }

    private void Update()
    {
        if (sun != null && !sun_already_moved && new_sun_location != null)
        {
            elapsed_time += Time.deltaTime;
            float percentage_complete = elapsed_time / desired_duration;
            sun.transform.position = Vector3.Lerp(original_sun_location, new_sun_location.transform.position, percentage_complete);
            sun.transform.eulerAngles = new Vector3(45, (Mathf.LerpAngle( 44.9f, opposite_rotation, percentage_complete)), 0);
            print("sun should be moving");
        }
    }

    public void Reset_Sun_Trigger()
    {
        sun_already_moved = false;
        elapsed_time = 0;
    }

    public void Reset_Sun()
    {
        sun_already_moved = false;
        elapsed_time = 0;
        if (sun != null)
        {
            sun.transform.position = original_sun_location;
            sun.transform.eulerAngles = new Vector3(45, 45, 0);
            new_sun_location = null;
        }
        
    }

    public GameObject Give_Sun()
    {
        return sun;
    }

    public void Sun_Change()
    {
        sun = GameObject.FindWithTag("sun finder").transform.parent.gameObject;
    }
}
