using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private PlayerData player1;
    [SerializeField] private PlayerData player2;
    [SerializeField] private GameSettingsData gameSettings;
    [SerializeField] private TMP_Text winnerAnnouncement;
    [SerializeField] private GameObject gameOverPanel;
    public UnityEvent onNewTurn;
    [HideInInspector]public PlayerData currentPlayer;
    public static event Action StartSliderSequence;
    public static event Action CalculateScore;
    public Difficulty difficulty;
    
    private bool _hasFinishedSequence;
    private bool _hasFinishedTurn;
    private bool _hasFinishedRound;
    bool _isPressed;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
        InputHandler.OnClick += (() => _isPressed = true);
        SliderManager.SequenceFinished += () => _hasFinishedSequence = true;
    }

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        difficulty = gameSettings.difficulty;
        Resume();
        StartCoroutine(Game());
    }

    public void QuitToMainMenu()
    {
        SceneLoader.Instance.LoadScene("MainMenuScene");
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    IEnumerator Game()
    {
        currentPlayer = player1;
        player1.AssignScore();
        player2.AssignScore();
        while (currentPlayer.PlayerScore > 0)
        {
            StartCoroutine(Round());
            yield return new WaitUntil(() => _hasFinishedRound);
            _hasFinishedRound = false;
        }
        StartCoroutine(AnnounceWinner());
    }

    IEnumerator Round()
    {
        currentPlayer = player1;
        StartCoroutine(Turn());
        yield return new WaitUntil(() => _hasFinishedTurn);
        _hasFinishedTurn = false;
        if (currentPlayer.PlayerScore <= 0) yield break;
        currentPlayer = player2;
        StartCoroutine(Turn());
        yield return new WaitUntil(() => _hasFinishedTurn);
        _hasFinishedTurn = false;
        if (currentPlayer.PlayerScore <= 0) yield break;
        _hasFinishedRound = true;
    }
    

    IEnumerator Turn()
    {
        //Announce which Players turn it is
        onNewTurn?.Invoke();
        StartSliderSequence?.Invoke();
        yield return new WaitUntil(() => _hasFinishedSequence);
        _hasFinishedSequence = false;
        //Shoot the Dart
        CalculateScore?.Invoke();
        //update the score UI
        _hasFinishedTurn = true;
    }

    IEnumerator AnnounceWinner()
    {
        gameOverPanel.SetActive(true);
        winnerAnnouncement.text = $"{currentPlayer.PlayerName}'s \n wins";
        yield return new WaitUntil(() => _isPressed);
        _isPressed = false;
        QuitToMainMenu();
    }
}
