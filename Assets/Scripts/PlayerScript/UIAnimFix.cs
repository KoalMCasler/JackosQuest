using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimFix : MonoBehaviour
{
    public Animator UIAnim;
    // Start is called before the first frame update
    void Start()
    {
        UIAnim.keepAnimatorStateOnDisable = true;
    }

}
