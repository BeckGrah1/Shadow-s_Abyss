using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private float num;
    [SerializeField] public string gameobject_tag;
    // Start is called before the first frame update
    void Start()
    {
        num = GameObject.FindGameObjectsWithTag(gameobject_tag).Length;
        if (num >= 2)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
