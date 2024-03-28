using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "InteractableObject", menuName = "Interaclables")]
public class InteractableScriptObject : ScriptableObject
{
    public bool HasMetPlayer;
    public bool IsQuestCompleated;
    public bool IsPickedUp;
    public bool IsActivated;
    public bool PickupCheck()
    {
        return IsPickedUp;
    }
}
