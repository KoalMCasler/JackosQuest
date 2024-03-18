using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    [Header("Remember to set Item Type")]
    public string message;
    private TextMeshProUGUI infoText;
    public enum ItemType{Nothing, Pickup, Info}
    public ItemType itemType;

    public void Start()
    {
        infoText = GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>();
        infoText.text = null;
        if(itemType == ItemType.Nothing)
        {
            Debug.Log(this.name + " Has a type of nothing, Was this by mistake?");
        }
    }


    public void Info()
    {
        Debug.Log("Reading info from " + this.name);
        //Debug.Log(message);
        StartCoroutine(ShowInfo(message, 2.5f));
    }


    public void Pickup()
    {
        Debug.Log("Picking up " + this.name);
        this.gameObject.SetActive(false);      
    }

    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = "";

    }

}
