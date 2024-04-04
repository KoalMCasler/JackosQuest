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
    public Animator playerAnim;   
    private Queue<string> dialogueQueue;
    [SerializeField] 
    private float textSpeed = 0.01f;
    public AudioSource textSFX;
    public AudioClip textSFXClip;
    void Start()
    {
        dialogueQueue = new Queue<string>();
        playerAnim = player.GetComponent<Animator>();
    }


    public void StartDialogue(string[] sentences)
    {
        dialogueQueue.Clear();
        dialogueUI.SetActive(true);
        player.GetComponent<CharacterController2D>().enabled = false;
        player.GetComponent<Interaction>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        playerAnim.SetBool("IsIdle", true);
        foreach(string currentLine in sentences)
        {
            dialogueQueue.Enqueue(currentLine);
        }
        DisplayNextSentence();
    }


    private void DisplayNextSentence()
    {
        if(dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string currentLine = dialogueQueue.Dequeue();
        StartCoroutine(ScrollingText(currentLine));
    }

    void EndDialogue()
    {
        dialogueQueue.Clear();
        dialogueUI.SetActive(false);
        playerAnim.SetBool("IsIdle", false);
        player.GetComponent<CharacterController2D>().enabled = true;
        player.GetComponent<Interaction>().enabled = true;
        if(player.GetComponent<Interaction>().currentInterObjScript.scriptableObject.IsQuestCompleated)
        {
            player.GetComponent<Interaction>().currentInterObjScript.EndQuest();
        }
    }
    private IEnumerator ScrollingText(string currentLine)
    {
        for(int i = 0; i < currentLine.Length + 1; i++)
        {
            dialogueText.text = currentLine.Substring(0,i);
            textSFX.PlayOneShot(textSFXClip,0.5f);
            yield return new WaitForSeconds(textSpeed);
        }
    }

}
