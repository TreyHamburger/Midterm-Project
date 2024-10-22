using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager[] levels;

    public static GameManager instance;

    private GameState currentState;
    private LevelManager currentLevel;
    private int currentLevelIndex = 0;

    public enum GameState
    {
        Briefing,
        LevelStart,
        LevelIn,
        LevelEnd,
        GameOver,
        GameEnd
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance);
            return;
        }

        instance = this;
    }

    private void Start()
    {
     if(levels.Length >0)
        {
            ChangeState(GameState.Briefing, levels[currentLevelIndex]);
        }
    }

    public void ChangeState(GameState state, LevelManager level)
    {
        currentState = state;
        currentLevel = level;

        switch (currentState)
        {
            case GameState.Briefing:
                StartBriefing();
                break;
            case GameState.LevelStart:
                InitiateLevel();
                break;
            case GameState.LevelIn:
                RunLevel();
                break;
            case GameState.LevelEnd:
                CompleteLevel();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.GameEnd:
                GameEnd();
                break;
        }
    }

    private void StartBriefing()
    {
        Debug.Log("Briefed Started...");

        ChangeState(GameState.LevelStart, currentLevel);
    }

    private void InitiateLevel()
    {
        Debug.Log("Level Start");

        currentLevel.StartLevel();
        ChangeState(GameState.LevelIn, currentLevel);
    }

    private void RunLevel()
    {
        Debug.Log("Level in " + currentLevel.gameObject.name);
    }

    private void CompleteLevel()
    {
        Debug.Log("Level End");

        //go to the next level
        ChangeState(GameState.LevelStart, levels[++currentLevelIndex]);
    }

    private void GameEnd()
    {
        Debug.Log("Game End, you in");
    } 

    private void GameOver()
    {
        Debug.Log("Game Over you lose");
    }
   
}
