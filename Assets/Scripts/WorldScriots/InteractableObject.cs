using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    [Header("Remember to set Item Type")]
    private GameObject player;
    private InventoryManager iM;
    [Header("Used By all Objects")]
    private TextMeshProUGUI infoText;
    public float InfoTextDelay;
    public enum ItemType{Nothing, Pickup, Info, Talks, Pillar, Portal, Door}
    public ItemType itemType;
    public string message;
    public AudioSource SFX;
    public InteractableScriptObject relatedQuestNPC;
    [Header("Used by NPCS")]
    public bool HasQuest;
    public string[] introSentences;
    public string[] questSentences;
    public string[] questFinshedSentences;
    public int questReqierment;
    public string questRequest;
    [Header("Used by Portal and Pillar")]
    public Animator ObjectAnimator;
    [Header("Used by doors")]
    public bool IsLocked;
    [Header("Used by all pickups, pillars, and NPCS")]
    public InteractableScriptObject scriptableObject;
    [Header("Used by Portal and last quest npc")]
    public LevelManager levelManager;
    private float textSpeed = 0.01f;


    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        IsLocked = true;
        infoText = GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>();
        infoText.text = null;
        if(itemType == ItemType.Nothing)
        {
            Debug.Log(this.name + " Has a type of nothing, Was this by mistake?");
        }
    }
    void Awake()
    {
        if(scriptableObject != null)
        {
            if(scriptableObject.PickupCheck())
            {
                this.gameObject.SetActive(false);
            }
            if(scriptableObject.IsQuestCompleated)
            {
                if(questRequest == "Flowers")
                {
                    this.gameObject.SetActive(false);
                }
                if(questRequest == "Coins")
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
    void Update()
    {
        if(scriptableObject != null)
        {
            if(scriptableObject.IsActivated == true)
            {
                ObjectAnimator.SetBool("IsActivated", true);
            }
            if(this.name == "Key")
            {
              if(relatedQuestNPC.IsQuestCompleated)
              {
                this.gameObject.SetActive(true);
              }
              else
              {
                this.gameObject.SetActive(false);
              }
            }
        }
        
    }
    public void Info()
    {
        Debug.Log("Reading info from " + this.name);
        //Debug.Log(message);
        StartCoroutine(ShowInfo(message, InfoTextDelay));
    }


    public void Pickup()
    {  
        Debug.Log("Picking up " + this.name);
        this.gameObject.SetActive(false);  
        if(scriptableObject != null)
        {
            scriptableObject.IsPickedUp = true;
        } 
    }
    public void Pillar()
    {
        if(!scriptableObject.IsActivated)
        {
            StartCoroutine(ShowInfo(message, InfoTextDelay));
            scriptableObject.IsActivated = true;
            player.GetComponent<Interaction>().PillarActiveCount += 1;
        }
    }
    public void Talks()
    {
        if(HasQuest && scriptableObject.HasExplainedQuest)
        {
            if(questRequest == "Coins")
            {
                if(iM.CoinCount >= questReqierment)
                {
                    iM.CoinCount -= questReqierment;
                    scriptableObject.IsQuestCompleated = true;
                }
            }
            if(questRequest == "Flowers")
            {
                if(iM.FlowerCount >= questReqierment)
                {
                    iM.FlowerCount -= questReqierment;
                    scriptableObject.IsQuestCompleated = true;
                }
            }
            if(questRequest == "Pillars")
            {
                if(iM.ActivePillarCount == questReqierment)
                {
                    scriptableObject.IsQuestCompleated = true;
                }
            }
            if(questRequest == "Potion")
            {
                if(iM.PotionCount >= questReqierment)
                {
                    iM.PotionCount-= questReqierment;
                    scriptableObject.IsQuestCompleated = true;
                }
            }
            if(questRequest == "Candle")
            {
                if(iM.CandleCount == questReqierment)
                {
                    iM.CandleCount -= questReqierment;
                    scriptableObject.IsQuestCompleated = true;
                }
            }
        }
        if(scriptableObject.HasMetPlayer == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(introSentences);
            scriptableObject.HasMetPlayer = true;
        }
        else if(!scriptableObject.IsQuestCompleated && scriptableObject.HasMetPlayer)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(questSentences);
            scriptableObject.HasExplainedQuest = true;
        }
        else if(scriptableObject.IsQuestCompleated && !scriptableObject.HasExplainedQuest)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(questSentences);
            scriptableObject.HasExplainedQuest = true;
        }
        else if(scriptableObject.IsQuestCompleated && scriptableObject.HasMetPlayer)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(questFinshedSentences);
        }
    }
    public void Door()
    {
        if(iM.KeyCount > 0)
        {
            IsLocked = false;
            iM.KeyCount -= 1;
            if(iM.KeyCount < 0)
            {
                iM.KeyCount = 0;
            }
            StartCoroutine(ShowInfo("Click", InfoTextDelay));
        }
        else if(IsLocked == true)
        {
            StartCoroutine(ShowInfo(message, InfoTextDelay));
        }
    }
    public void Portal()
    {
        if(player.GetComponent<Interaction>().PillarActiveCount < 4)
        {
            StartCoroutine(ShowInfo(message, InfoTextDelay));
        }
        else
        {
            player.GetComponent<Animator>().SetTrigger("PlayerTP");
            levelManager.LoadThisScene("Gameplay 5");
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.gameObject;
            iM = FindObjectOfType<InventoryManager>();
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player = null;
            iM = null;
        }
    }
    IEnumerator ShowInfo(string message, float delay)
    {
        StartCoroutine(ScrollingText(message));
        yield return new WaitForSeconds(delay);
        infoText.text = "";
    }
    public void EndQuest()
    {
        if(questRequest == "Flowers")
        {
            if(this.gameObject.GetComponent<NPCAnimator>().IsQuestCompleated == false)
            {
                this.gameObject.GetComponent<NPCAnimator>().IsQuestCompleated = true;
            }
        }
        if(questRequest == "Coins")
        {
            this.gameObject.SetActive(false);
        }
        if(questRequest == "Candle")
        {
            levelManager.LoadThisScene("GameOver");
        }
    }
    private IEnumerator ScrollingText(string currentLine)
    {
        for(int i = 0; i < currentLine.Length + 1; i++)
        {
            infoText.text = currentLine.Substring(0,i);
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
