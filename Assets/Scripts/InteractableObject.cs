using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    [Header("Remember to set Item Type")]
    public string message;
    private TextMeshProUGUI infoText;
    public enum ItemType{Nothing, Pickup, Info, Talks, Pillar, Portal}
    public ItemType itemType;
    public string[] sentences;
    public bool IsQuestrelated;
    public bool IsActivated;
    public Animator ObjectAnimator;
    private GameObject player;

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
        StartCoroutine(ShowInfo(message, 0.5f));   
        Debug.Log("Picking up " + this.name);
        this.gameObject.SetActive(false);   
    }
    public void Pillar()
    {
        if(!IsActivated)
        {
            StartCoroutine(ShowInfo(message, 2.5f));
            IsActivated = true;
            ObjectAnimator.SetBool("IsActivated", true);
            player.GetComponent<Interaction>().PillarActiveCount += 1;
        }
    }
    public void Talks()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(sentences);
    }
    public void Portal()
    {
        if(player.GetComponent<Interaction>().PillarActiveCount < 4)
        {
            StartCoroutine(ShowInfo(message, 2.5f));
        }
        else
        {

        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player = null;
        }
    }
    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = "";

    }

}
