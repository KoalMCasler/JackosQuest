using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAnimator : MonoBehaviour
{
    public Animator portalAnim;
    void Start()
    {
        portalAnim = this.GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") == true)
        {
            portalAnim.SetBool("IsActive", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") == true)  
        {
            portalAnim.SetBool("IsActive", false);
        }
    }

}
