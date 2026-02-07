using System;
using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private PlayerData player1;
    [SerializeField] private PlayerData player2;
    [HideInInspector]public PlayerData currentPlayer;
    public static event Action StartSliderSequence;
    public static event Action CalculateScore;
    
    private bool _hasFinishedSequence;
    private bool _hasFinishedTurn;
    private bool _hasFinishedRound;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
        SliderManager.SequenceFinished += () => _hasFinishedSequence = true;
    }

    void Start()
    {
        StartCoroutine(Game());
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
        StartSliderSequence?.Invoke();
        yield return new WaitUntil(() => _hasFinishedSequence);
        _hasFinishedSequence = false;
        //Shoot the Dart
        CalculateScore?.Invoke();
        //update the score UI
        _hasFinishedTurn = true;
    }
}
