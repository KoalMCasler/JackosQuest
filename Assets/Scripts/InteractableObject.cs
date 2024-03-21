using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    [Header("Remember to set Item Type")]
    public string message;
    private TextMeshProUGUI infoText;
    public enum ItemType{Nothing, Pickup, Info, Talks}
    public ItemType itemType;
    public string[] sentences;

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
        StartCoroutine(ShowInfo(message, 0.5f));   
    }
    public void Talks()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(sentences);
    }
    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = "";

    }

}
