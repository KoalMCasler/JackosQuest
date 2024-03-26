using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelEnter : MonoBehaviour
{
    private GameObject Entrance;
    private GameObject Exit;
    public Vector3 EnterOffset;
    public Vector3 ExitOffset;
    [SerializeField]
    public SceneInfo sceneInfo;
    private Rigidbody2D Player;
    
    
    void Awake()
    {
        Player = gameObject.GetComponent<Rigidbody2D>();
        Entrance = GameObject.FindWithTag("Enter");
        Exit = GameObject.FindWithTag("Exit");
        EnterOffset = Entrance.GetComponent<LevelMove>().OffsetObject.transform.position;
        ExitOffset = Exit.GetComponent<LevelMove>().OffsetObject.transform.position;
    }
    void OnEnable()
    {
        MovePlayer();
    }
    void Start()
    {
        MovePlayer();
    }
    public void MovePlayer()
    {
        if(Entrance == null)
            {return;}
        if(Exit == null)
            {return;}
        GameObject target = sceneInfo.IsNextScene ? Entrance : Exit;
        Vector3 Offset = sceneInfo.IsNextScene ? EnterOffset : ExitOffset;

        Player.position =  Offset;
    }
}
