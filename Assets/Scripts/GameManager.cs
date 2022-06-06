using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singelton<GameManager>
{
    public GameObject StartP, InGameP, NextP, GameOverP;
    float Countdown = 2f;
    public enum GameState
    {
    Start,
    Ingame,
    Next,
    Gameover
    }
    public GameState gamestate;

    public enum Panels
    {
    Startp,
    Nextp,
    GameOverp,
    InGamep
    }
    private void Start()
    {
        gamestate = GameState.Start;
    }
    private void Update()
    {
        switch (gamestate) 
        {
            case GameState.Start: GameStart();
                break;
            case GameState.Ingame: GameIngame();
                break;
            case GameState.Next:   GameFinisih();
                break;
            case GameState.Gameover: GameOver();
                break;
        }
    }
    void PanelController(Panels currentPanels)
    {
       
        StartP.SetActive(false);
        InGameP.SetActive(false);
       NextP.SetActive(false);
       GameOverP.SetActive(false);
       switch(currentPanels)
        {
            case Panels.Startp:  StartP.SetActive(false);
                break;
            case Panels.InGamep:  InGameP.SetActive(false);
                break;   
            case Panels.Nextp:     NextP.SetActive(false);
                break;
            case Panels.GameOverp: GameOverP.SetActive(false);
                break;
        }

    }



    void GameStart()
    {
        PanelController(Panels.Startp);
    }
    void GameIngame()
    {
        PanelController(Panels.InGamep);
    }
    void GameFinisih()
    {
        PanelController(Panels.Nextp);

    }
    void GameOver()
    {
        PanelController(Panels.GameOverp);

    }
    public void RestartButton()
    {

    }

    public void NextLevelButton()
    {

    }
}
