using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public Animator crossFadeAnim;
    public float warpDelay;
    public GameObject player;
    // Transform of object set as destination from object.
    [SerializeField] 
    private Transform destination;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.gameObject;
            StartCoroutine(Teleport());
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player = null;
        }
    }
    private IEnumerator Teleport()
    {
        crossFadeAnim.SetBool("Start", true);
        yield return new WaitForSeconds(warpDelay);
        player.transform.position = destination.transform.position;
        crossFadeAnim.SetBool("Start", false);
        
    }
}
