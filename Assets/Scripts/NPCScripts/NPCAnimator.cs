using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimator : MonoBehaviour
{
    public Animator npcAnim;
    public bool IsQuestCompleated;
    void Start()
    {
        IsQuestCompleated = false;
    }

    // Update is called once per frame
    void Update()
    {
       npcAnim.SetBool("IsQuestCompleated", IsQuestCompleated);
    }
   
}
