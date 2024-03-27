using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uIManager;
    public LevelManager levelManager;
    public CharacterController2D playerController;

    public GameObject player;
    public GameObject spawnPoint;
    public GameObject playerArt;

    public enum GameState{ MainMenu, Gameplay, Paused, Options, GameOver, GameWin}

    public GameState gameState;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameState = GameState.MainMenu;

        levelManager = FindObjectOfType<LevelManager>();

        uIManager = FindObjectOfType<UIManager>();

        playerController = FindObjectOfType<CharacterController2D>();
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
        player.SetActive(false);
        uIManager.SetMainMenu();
    }
    void Gameplay()
    {
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
}
