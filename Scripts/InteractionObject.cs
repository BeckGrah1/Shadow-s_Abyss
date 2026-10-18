using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class InteractionObject : MonoBehaviour
{
    [SerializeField] private string interactionText;
    private string savedInteractionText;
    [SerializeField] string bookText;
    [SerializeField] string paperText;

    public UnityEvent OnInteract = new UnityEvent();

    private void Start()
    {
        savedInteractionText = interactionText;
    }
    public string GetInteractionText()
    {
        return interactionText;
    }

    public string GetBookText()
    {
        return bookText;
    }

    public void Interact()
    {
        OnInteract.Invoke();
        if (paperText != "" && GameObject.FindWithTag("paper text").GetComponent<TMP_Text>().text == "")
        {
            GameObject.FindWithTag("Player").GetComponent<InputHandler>().Toggle_Movement();
            GameObject.FindWithTag("Player").GetComponent<InputHandler>().Toggle_Camera();
            GameObject.FindWithTag("canvas").transform.Find("Paper").gameObject.SetActive(true);
            GameObject.FindWithTag("paper text").GetComponent<TMP_Text>().text = paperText;
        }
        else if (bookText != "" && GameObject.FindWithTag("book text").GetComponent<TMP_Text>().text == "")
        {
            GameObject.FindWithTag("Player").GetComponent<InputHandler>().Toggle_Movement();
            GameObject.FindWithTag("Player").GetComponent<InputHandler>().Toggle_Camera();
            GameObject.FindWithTag("canvas").transform.Find("Paper").gameObject.SetActive(true);
            GameObject.FindWithTag("book text").GetComponent<TMP_Text>().text = bookText;
        }
        else if (GameObject.FindWithTag("Player").GetComponent<InputHandler>().Return_Movement() == false)
        {
            GameObject.FindWithTag("Player").GetComponent<InputHandler>().Toggle_Movement();
            GameObject.FindWithTag("Player").GetComponent<InputHandler>().Toggle_Camera();
            GameObject.FindWithTag("canvas").transform.Find("Paper").gameObject.SetActive(false);
            GameObject.FindWithTag("paper text").GetComponent<TMP_Text>().text = "";
            GameObject.FindWithTag("book text").GetComponent<TMP_Text>().text = "";
        }
    }

    public void Disable_Interaction_Text()
    {
        interactionText = "";
    }

    public void Revert_Interaction_Text()
    {
        interactionText = savedInteractionText;
    }
}
