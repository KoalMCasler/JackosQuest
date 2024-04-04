using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject player;
    public GameObject mainCamera;
    public Collider2D foundBoundingShape;
    public CinemachineConfiner2D confiner2D;
    public GameObject Entrance;
    public GameObject Exit;
    public GameObject EnterOffset;
    public GameObject ExitOffset;
    public SceneInfo sceneInfo;
    public float SceneChangeDelay;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public void LoadThisScene(string sceneName)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if(sceneName.StartsWith("Gameplay"))
        {
            gameManager.gameState = GameManager.GameState.Gameplay;
        }
        if(sceneName == "MainMenu")
        {
            gameManager.gameState = GameManager.GameState.MainMenu;
        }
        if(sceneName.StartsWith("GameOver"))
        {
            gameManager.gameState = GameManager.GameState.GameOver;
        }
        StartCoroutine(LoadSceneWithDealy(sceneName));
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Entrance = GameObject.FindWithTag("Enter");
        Exit = GameObject.FindWithTag("Exit");
        EnterOffset = GameObject.FindWithTag("EnterOffset");
        ExitOffset = GameObject.FindWithTag("ExitOffset");
        foundBoundingShape = GameObject.FindWithTag("Confiner").GetComponent<Collider2D>();
        confiner2D.m_BoundingShape2D = foundBoundingShape;
        mainCamera = GameObject.FindWithTag("MainCamera");
        GameObject target = sceneInfo.IsNextScene ? Entrance : Exit;
        Vector3 Offset = sceneInfo.IsNextScene ? EnterOffset.transform.position : ExitOffset.transform.position;
        player.transform.position =  Offset;
    }
    IEnumerator LoadSceneWithDealy(string sceneName)
    {
        yield return new WaitForSeconds(SceneChangeDelay);
        SceneManager.LoadScene(sceneName);
    }
}
