using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public static Action<GameState> OnGameStateChange;

    void Start()
    {
        SwitchState(GameState.Play);
    }
    
    void SwitchState(GameState state)
    {
        gameState = state;
        switch (state)
        {
            case GameState.Initialize:
            {
                break;
            }
            case GameState.Play:
            {
                break;
            }
        }
        OnGameStateChange?.Invoke(gameState);
    }
}

public enum GameState
{
    Initialize,
    Play
}
