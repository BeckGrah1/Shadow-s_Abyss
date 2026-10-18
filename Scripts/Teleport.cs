using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<CharacterController>().enabled = false;
        GameObject.FindWithTag("Player").transform.position = this.gameObject.transform.position;
        GameObject.FindWithTag("Player").GetComponent<CharacterController>().enabled = true;
    }
}
