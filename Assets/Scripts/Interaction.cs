using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
   public GameObject currentInterObj = null;
    public InteractableObject currentInterObjScript = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentInterObj == true)
        {
            if (currentInterObjScript.itemType == InteractableObject.ItemType.Info)
            {
                currentInterObjScript.Info();
            }
            if (currentInterObjScript.itemType == InteractableObject.ItemType.Pickup)
            {
                currentInterObjScript.Pickup();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Interactable") == true)
        {
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractableObject>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable") == true)  
        {
            currentInterObj = null;
        }
    }
}
