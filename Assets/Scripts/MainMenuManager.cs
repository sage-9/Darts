using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Color easyColor;
    [SerializeField] private Color mediumColor;
    [SerializeField] private Color hardColor;
    [SerializeField] private Image[] colorChangeUI;
    [SerializeField] private TMP_Text[] colorChangeText;
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] private TMP_InputField player1NameInput;
    [SerializeField] private TMP_InputField player2NameInput;
    [SerializeField] private PlayerData player1Data;
    [SerializeField] private PlayerData player2Data;
    [SerializeField] private GameSettingsData gameSettingsData;

    
    
    void Start()
    {
        slider.value = 0;
    }
    
    public void Play()
    {
        SceneLoader.Instance.LoadScene("Game Scene");
    }

    public void AssignNames()
    {
        player1Data.AssignName(player1NameInput.text);
        player2Data.AssignName(player2NameInput.text);
    }
    public void Quit()
    {
        Application.Quit();
    }
    
    
    void ChangeColour(Color color)
    {
        foreach (var Image in colorChangeUI)
        {
            Image.color = color;
        }

        foreach (var Text in colorChangeText)
        {
            Text.color = color;
        }
    }
    
    void SetDifficulty(int difficulty)
    {
        switch (difficulty)
        {
            case 0:
            {
                ChangeColour(easyColor);
                colorChangeText[0].text = "Easy";
                gameSettingsData.difficulty = Difficulty.Easy;
                break;
            }
            case 1:
            {
                ChangeColour(mediumColor);
                colorChangeText[0].text = "Medium";
                gameSettingsData.difficulty = Difficulty.Medium;
                break;
            }
            case 2:
            {
                ChangeColour(hardColor);
                colorChangeText[0].text = "Hard";
                gameSettingsData.difficulty = Difficulty.Hard;
                break;
            }
            default:
            {
                colorChangeText[0].text = "Easy";
                ChangeColour(easyColor);
                gameSettingsData.difficulty = Difficulty.Easy;
                break;
            }
        }
    }
    
    public void OnSliderValueChanged()
    {
        SetDifficulty((int)slider.value);
    }
}
