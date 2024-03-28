using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    public UIManager uIManager;
    public LevelManager levelManager;
    public CharacterController2D playerController;
    public InventoryManager inventoryManager;

    [Header("Object Referances")]

    public GameObject player;
    public GameObject spawnPoint;
    public GameObject playerArt;
    public GameObject menuAnimation;

    public enum GameState{ MainMenu, Gameplay, Paused, Options, GameOver, GameWin}
    [Header("Game State")]
    public GameState gameState;
    [Header("Scriptable Objects")] //needed to reset progress.
    public InteractableScriptObject pillarQuest;
    public InteractableScriptObject coinQuest;
    public InteractableScriptObject potionQuest;
    public InteractableScriptObject flowerQuest;
    public InteractableScriptObject candleQuest;
    public InteractableScriptObject[] Pickups;
    public InteractableScriptObject[] Pillars;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameState = GameState.MainMenu;

        levelManager = FindObjectOfType<LevelManager>();

        uIManager = FindObjectOfType<UIManager>();

        playerController = FindObjectOfType<CharacterController2D>();
        
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        switch(gameState)
        {
            case GameState.MainMenu: MainMenu(); break;
            case GameState.Gameplay: Gameplay(); break;
            case GameState.Paused: Paused(); break;
            case GameState.Options: Options(); break;
            case GameState.GameOver: GameOver(); break;
            case GameState.GameWin: GameWin(); break;
        }
    }
    void MainMenu()
    {
        ResetObjects();
        menuAnimation.SetActive(true);
        player.SetActive(false);
        uIManager.SetMainMenu();
    }
    void Gameplay()
    {
        menuAnimation.SetActive(false);
        player.SetActive(true);
        uIManager.SetHUDActive();
    }
    void Paused()
    {
        uIManager.GameIsPause = true;
        uIManager.SetPauseMenu();
    }
    void Options()
    {
        player.SetActive(false);
        uIManager.SetOptionsMenu();
    }
    void GameOver()
    {
        player.SetActive(false);
        uIManager.SetGameOver();
    }
    void GameWin()
    {
        player.SetActive(false);
        uIManager.SetGameWin();
    }
    public void QuitGame()
    {
        //Debug line to test quit function in editor
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    void ResetObjects()
    {
        inventoryManager.ResetProgress();

        pillarQuest.HasMetPlayer = false;
        pillarQuest.IsQuestCompleated = false;
        candleQuest.HasMetPlayer = false;
        candleQuest.IsQuestCompleated = false;
        coinQuest.HasMetPlayer = false;
        coinQuest.IsQuestCompleated = false;
        flowerQuest.HasMetPlayer = false;
        flowerQuest.IsQuestCompleated = false;
        potionQuest.HasMetPlayer = false;
        potionQuest.IsQuestCompleated = false;

        for(int i = 0; i < Pickups.Length; i++ )
        {
            Pickups[i].IsPickedUp = false;
        }
        for(int i = 0; i < Pillars.Length; i++ )
        {
            Pillars[i].IsActivated = false;
        }
    }
}
