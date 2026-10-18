using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSunBool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<TimeWarpPotion>().Reset_Sun_Trigger();
    }
}
