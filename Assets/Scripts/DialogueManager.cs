using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public TextMeshProUGUI dialogueText;
    public GameObject player;
    public Animator animator;   
    private Queue<string> dialogueQueue;
    
    void Start()
    {
        dialogueQueue = new Queue<string>();
    }


    public void StartDialogue(string[] sentences)
    {
        dialogueQueue.Clear();
        dialogueUI.SetActive(true);
        player.GetComponent<CharacterController2D>().enabled = false;
        player.GetComponent<Interaction>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        foreach(string currentLine in sentences)
        {
            dialogueQueue.Enqueue(currentLine);
        }
        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if(dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string currentLine = dialogueQueue.Dequeue();

        dialogueText.text = currentLine;
    }

    void EndDialogue()
    {
        dialogueQueue.Clear();
        dialogueUI.SetActive(false);
        player.GetComponent<CharacterController2D>().enabled = true;
        player.GetComponent<Interaction>().enabled = true;
    }



}
