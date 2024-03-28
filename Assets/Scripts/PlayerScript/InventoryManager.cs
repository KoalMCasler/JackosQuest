using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InventoryManager : MonoBehaviour
{
    public int ActivePillarCount;
    public int CoinCount;
    public int FlowerCount;
    public int KeyCount;
    public TextMeshProUGUI PillarObject;
    public TextMeshProUGUI CoinObject;
    public TextMeshProUGUI FlowerObject;
    public TextMeshProUGUI KeyObject;
    // Start is called before the first frame update
    void Start()
    {
        ActivePillarCount = 0;
        CoinCount = 0;
        FlowerCount = 0;
        KeyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PillarObject.text = string.Format("{0}/4",ActivePillarCount);
        CoinObject.text = string.Format("{0}",CoinCount);
        FlowerObject.text = string.Format("{0}",FlowerCount);
        KeyObject.text = string.Format("{0}",KeyCount);
    }
}
