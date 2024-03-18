using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject PauseMenu;
    public GameObject HUD;
    public GameObject GameWin;
    public GameObject GameOver;
    public GameManager gameManager;
    public bool GameIsPause;
    void Start()
    {
        SetMainMenu();
    }
    void Update()
    {
        if(GameIsPause == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    void ResetObjects()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        PauseMenu.SetActive(false);
        HUD.SetActive(false);
        GameOver.SetActive(false);
        GameWin.SetActive(false);
    }
    public void SetMainMenu()
    {
        ResetObjects();
        MainMenu.SetActive(true);
        GameIsPause = false;
    }
    public void SetOptionsMenu()
    {
        ResetObjects();
        OptionsMenu.SetActive(true);
    }
    public void SetPauseMenu()
    {
        ResetObjects();
        PauseMenu.SetActive(true);
        GameIsPause = true;
    }
    public void SetHUDActive()
    {
        ResetObjects();
        HUD.SetActive(true);
    }
    public void SetGameOver()
    {
        ResetObjects();
        GameOver.SetActive(true);
        GameIsPause = false;
    }
    public void SetGameWin()
    {
        ResetObjects();
        GameWin.SetActive(true);
        GameIsPause = false;
    }
    public void OpenOptionsMenu()
    {
        gameManager.gameState = GameManager.GameState.Options;
    }
    public void BackFromOptions()
    {
        if(!GameIsPause)
        {
            gameManager.gameState = GameManager.GameState.MainMenu;
        }
        if(GameIsPause)
        {
            gameManager.gameState = GameManager.GameState.Paused;
        }
    }
    public void ResumeGame()
    {
        GameIsPause = false;
        gameManager.gameState = GameManager.GameState.Gameplay;
    }
}
