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
    public AudioSource coinSound;

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
            if(other.name == "Coin")
            {
                Interact();
            }
            if(currentInterObjScript.scriptableObject.IsActivated != true && other.name != "Coin")
            {
                indicator.SetActive(true);
            }
            if(currentInterObjScript.itemType == InteractableObject.ItemType.Door && currentInterObjScript.IsLocked == false)
            {
                currentInterObj = null;
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
        if(!currentInterObjScript.scriptableObject.IsActivated)
        {
            if(currentInterObjScript.itemType == InteractableObject.ItemType.Info)
            {
                currentInterObjScript.Info();
            }
            if(currentInterObjScript.itemType == InteractableObject.ItemType.Pickup)
            {
                if(currentInterObj.name == "Coin")
                {
                    coinSound.Play();
                    inventoryManager.CoinCount += 1;
                }
                if(currentInterObj.name == "Flower")
                {
                    inventoryManager.FlowerCount += 1;
                }
                if(currentInterObj.name == "Key")
                {
                    inventoryManager.KeyCount += 1;
                }
                if(currentInterObj.name == "Potion")
                {
                    inventoryManager.PotionCount += 1;
                }
                if(currentInterObj.name == "Candle")
                {
                    inventoryManager.CandleCount += 1;
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
            if(currentInterObjScript.itemType == InteractableObject.ItemType.Door)
            {
                currentInterObjScript.Door();
            }
        }
    }
}
