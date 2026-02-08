using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public event Action OnScoreChanged;
    public string PlayerName { get; private set; }
    public int PlayerScore {get; private set;}

    public void AssignName(string playerName = "Player")
    {
        this.PlayerName = playerName;
    }

    public void AssignScore(int playerScore = 301)
    {
        this.PlayerScore = playerScore;
        OnScoreChanged?.Invoke();
    }

    public void SubtractScore(int amount)
    {
        PlayerScore -= amount;
        OnScoreChanged?.Invoke();
    }
}
