using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpText : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI pickupText;

    public IEnumerator DisplayPickUpText(string objectName)
    {
        print("coroutine started");
        pickupText.SetText("Picked up the " + objectName);
        print("text displayed");
        yield return new WaitForSeconds(2f);
        print("waited");
        pickupText.SetText("");
    }
}
