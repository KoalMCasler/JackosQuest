using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingText : MonoBehaviour
{
    [Header("Text Settings")]
    [SerializeField] [TextArea] 
    public string[] stringArray;
    [SerializeField] 
    private float textSpeed = 0.01f;
    
    [Header("UI Elements")]

    [SerializeField] 
    private TextMeshProUGUI dialogue;
    private int currentDisplayingText = 0;

    public void ActiavteText()
    {
        StartCoroutine(AnimateText());
    }
    public IEnumerator AnimateText()
    {
        for(int i = 0; i < stringArray[currentDisplayingText].Length + 1; i++)
        {
            dialogue.text = stringArray[currentDisplayingText].Substring(0,i);
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
