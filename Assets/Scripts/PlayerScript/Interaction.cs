using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractableObject currentInterObjScript = null;
    public GameObject indicator;
    public int PillarActiveCount;
    public InventoryManager inventoryManager;

    void Start()
    {
        PillarActiveCount = 0;
        indicator.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && currentInterObj == true)
        {
            Interact();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Interactable") == true)
        {
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractableObject>();
            if(currentInterObjScript.IsActivated != true)
            {
                indicator.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Interactable") == true)  
        {
            currentInterObj = null;
            indicator.SetActive(false);
        }
    }
    void Interact()
    {
        if(!currentInterObjScript.IsActivated)
        {
            if(currentInterObjScript.itemType == InteractableObject.ItemType.Info)
            {
                currentInterObjScript.Info();
            }
            if(currentInterObjScript.itemType == InteractableObject.ItemType.Pickup)
            {
                if(currentInterObj.name == "Coin")
                {
                    inventoryManager.CoinCount += 1;
                }
                if(currentInterObj.name == "Flower")
                {
                    inventoryManager.FlowerCount += 1;
                }
                currentInterObjScript.Pickup();
            }
            if(currentInterObjScript.itemType == InteractableObject.ItemType.Talks)
            {
                currentInterObjScript.Talks();
            }
            if(currentInterObjScript.itemType == InteractableObject.ItemType.Pillar)
            {
                currentInterObjScript.Pillar();
                inventoryManager.ActivePillarCount = PillarActiveCount;
            }
            if(currentInterObjScript.itemType == InteractableObject.ItemType.Portal)
            {
                currentInterObjScript.Portal();
            }
        }
    }
}
