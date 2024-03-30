using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimator : MonoBehaviour
{
    public Animator npcAnim;
    public Rigidbody2D npcRB;
    public bool IsIdle;
    public Vector2 moveTarget;
    void Start()
    {
        npcRB = this.gameObject.GetComponent<Rigidbody2D>();
        IsIdle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(npcRB.velocity.x == 0 && npcRB.velocity.y == 0)
        {
            IsIdle = true;
        }
        else
        {
            IsIdle = false;
        }
        npcAnim.SetBool("IsIdle", IsIdle);
        if(!IsIdle)
        {
            npcAnim.SetFloat("moveX",npcRB.velocity.x);
            npcAnim.SetFloat("moveY",npcRB.velocity.y);
        }
        else
        {
            npcAnim.SetFloat("moveX", 0);
            npcAnim.SetFloat("moveY", 0);
        }
    }
    public void MoveNPC()
    {
        npcRB.MovePosition(moveTarget * Time.deltaTime);
    }
}
