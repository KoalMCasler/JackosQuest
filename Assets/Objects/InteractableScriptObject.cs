using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "InteractableObject", menuName = "Interaclables")]
public class InteractableScriptObject : ScriptableObject
{
    public bool HasMetPlayer;
    public bool HasExplainedQuest;
    public bool IsQuestCompleated;
    public bool EverythingFinished;
    public bool IsPickedUp;
    public bool IsActivated;
    public bool PickupCheck()
    {
        return IsPickedUp;
    }
}
