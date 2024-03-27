using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractableObject currentInterObjScript = null;
    public TextMeshProUGUI CoinCounter;
    public int coinCount;
    public GameObject indicator;
    public int PillarActiveCount;

    void Start()
    {
        PillarActiveCount = 0;
        indicator.SetActive(false);
        coinCount = 0;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && currentInterObj == true)
        {
            Interact();
        }
        CoinCounter.text = string.Format("You have {0} coins", coinCount);
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
                    coinCount += 1;
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
            }
            if(currentInterObjScript.itemType == InteractableObject.ItemType.Portal)
            {
                currentInterObjScript.Portal();
            }
        }
    }
}
