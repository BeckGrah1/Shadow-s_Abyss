using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.UI.Image;
using System.Linq;



public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float maxDistance = 2f;
    [SerializeField] GameObject look_at_text;
    private InteractionObject targetInteraction;
    GameObject transparencyCheckGameObject;
    GameObject transparentedObject;
    List<GameObject> torch_list;

    // Start is called before the first frame update
    void Start()
    {
        torch_list = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        RaycastHit raycastHit = new RaycastHit();
        string interactionText = "";
        look_at_text.GetComponent<TMP_Text>().SetText(interactionText);
        targetInteraction = null;

        if (Physics.Raycast(origin, direction, out raycastHit, maxDistance))
        {
            targetInteraction = raycastHit.collider.gameObject.GetComponent<InteractionObject>();
        }

        if (targetInteraction)
        {
            interactionText = targetInteraction.GetInteractionText();
            look_at_text.GetComponent<TMP_Text>().SetText(interactionText);

        }


    }

    public void TryInteract()
    {
        if (targetInteraction)
        {
            targetInteraction.Interact();
        }
    }

    public bool Torch_Check()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        RaycastHit raycastHit = new RaycastHit();
        if (Physics.Raycast(origin, direction, out raycastHit, maxDistance))
        {
            if (raycastHit.collider.gameObject.GetComponent<InteractionObject>())
            {
                targetInteraction = raycastHit.collider.gameObject.GetComponent<InteractionObject>();
                if (targetInteraction.gameObject.tag == "torch")
                {
                    torch_list.Add(targetInteraction.gameObject);
                    targetInteraction.gameObject.transform.Find("Unlit Torch").gameObject.SetActive(false);
                    targetInteraction.gameObject.transform.Find("Lit Torch").gameObject.SetActive(true);
                    targetInteraction.gameObject.tag = "lit torch";
                    this.gameObject.GetComponent<LightTracker>().Change_Light_List();
                    return true;
                }
            }
            else { return false; }
        }
        return false;
    }

    public bool Transparency_Check()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        RaycastHit raycastHit = new RaycastHit();
        transparencyCheckGameObject = null;
        if (Physics.Raycast(origin, direction, out raycastHit, maxDistance))
        {
            transparencyCheckGameObject = raycastHit.collider.gameObject;
            if (transparencyCheckGameObject.layer == 6)
            {
                for (int i = 0; i < transparencyCheckGameObject.transform.childCount; i++)
                {
                    Transform child = transparencyCheckGameObject.transform.GetChild(i);
                    if (child.tag == "transparent object")
                    {
                        child.gameObject.SetActive(true);
                        child.parent = null;
                        transparentedObject = child.gameObject;
                        transparencyCheckGameObject.SetActive(false);
                        return true;
                    }

                }
                return false;
            }
            else { return false; }
        }
        else { return false; }
    }

    public void Reset_Transparent_Objects()
    {
        if (transparentedObject != null)
        {
            transparencyCheckGameObject.SetActive(true);
            transparentedObject.transform.SetParent(transparencyCheckGameObject.transform);
            transparentedObject.SetActive(false);
            transparentedObject = null;
        }
        transparencyCheckGameObject = null;

    }

    public void Reset_Torches()
    {
        //print("torch list length: " + torch_list.Count());
        for (int i = 0; i < torch_list.Count; i++)
        {
            if (torch_list[i] != null)
            {
                torch_list[i].gameObject.transform.Find("Unlit Torch").gameObject.SetActive(true);
                torch_list[i].gameObject.transform.Find("Lit Torch").gameObject.SetActive(false);
                torch_list[i].tag = "torch";
                this.gameObject.GetComponent<LightTracker>().Change_Light_List();
            }
            
        }
        torch_list = new List<GameObject>();
    }
}
