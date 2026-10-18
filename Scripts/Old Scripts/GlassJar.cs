using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlassJar : MonoBehaviour
{
    public bool jarPickup = false;
    public bool textDisplayed = false;
    [SerializeField] public GameObject Jar_UI;
    [SerializeField] public GameObject jarInfo;
    [SerializeField] public GameObject seeThroughWallCollider;
    [SerializeField] public Material transparentMaterial;
    [SerializeField] public Material standardMaterial;
    [SerializeField] public Renderer meshRenderer;

    // Update is called once per frame
    void Update()
    {

        Jar_UI.SetActive(false);
        seeThroughWallCollider.SetActive(true);
        meshRenderer.material = standardMaterial;

        if (jarPickup == true)
        {
            if (textDisplayed == false)
            {
                StartCoroutine(DisplayInfoText());
            }

            if (Input.GetMouseButton(0))
            {
                Jar_UI.SetActive(true);
                seeThroughWallCollider.SetActive(false);
                meshRenderer.material = transparentMaterial;
            }
        }
        
    }

    public void JarPickedUp()
    {
        jarPickup = true;
        
    }

    private IEnumerator DisplayInfoText()
    {
        jarInfo.SetActive(true);
        textDisplayed = true;
        yield return new WaitForSeconds(4f);
        jarInfo.SetActive(false);
    }
}
