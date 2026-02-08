using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GameSettingsData", menuName = "Scriptable Objects/GameSettingsData")]
public class GameSettingsData : ScriptableObject
{
    public Difficulty difficulty;
}

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}
