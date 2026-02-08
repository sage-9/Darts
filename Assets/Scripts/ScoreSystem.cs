using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]private Transform boardCentre;
    [SerializeField]private float boardRadius;
    [SerializeField]private TMP_Text scoreText;
    private float _score;
    private readonly int[] _scoreSlices = { 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5 };

    void Awake()
    {
        SliderManager.CalculateScore += CalculateScore;
    }

    private void CalculateScore(Vector2 hitPosition)
    {
        //Get local position relative to board center
        Vector2 localHit = hitPosition - (Vector2)boardCentre.position;
        float distance = localHit.magnitude;

        //Check if it's off the board
        if (distance > boardRadius)
        {
            Debug.Log("Miss! Out of bounds.");
            return;
        }

        //Calculate Angle (Degrees)
        float angle = Mathf.Atan2(localHit.y, localHit.x) * Mathf.Rad2Deg;
        float adjustedAngle = (90f - angle + 360f) % 360f;

        //Determine Slice (Each slice is 18 degrees)
        int sliceIndex = Mathf.FloorToInt((adjustedAngle + 9f) / 18f) % 20;
        int baseScore = _scoreSlices[sliceIndex];

        //Apply Multipliers based on distance
        int finalScore = ApplyMultipliers(baseScore, distance);
        if (finalScore <= GameManager.Instance.currentPlayer.PlayerScore)
        {
            GameManager.Instance.currentPlayer.SubtractScore(finalScore);
        }

        StartCoroutine(AnnounceScore(finalScore));

    }

    private int ApplyMultipliers(int baseScore, float dist)
    {
        // Example logic:
        if ((dist/boardRadius) < 0.03f) return 50; // Bullseye
        if ((dist/boardRadius) < 0.07f) return 25; // Outer Bull
        if((dist/boardRadius) < 0.52f) return baseScore;//Single Inner
        if ((dist/boardRadius) < 0.58f) return baseScore * 3;//Triple Ring
        if ((dist / boardRadius) < 0.88f) return baseScore;//Single Outer
        if ((dist / boardRadius) < 0.95f) return baseScore * 2;//Double Ring
        return 0;//outside the points area
    }

    IEnumerator AnnounceScore(int finalScore)
    {
        scoreText.text = finalScore.ToString();
        yield return new WaitForSeconds(0.5f);
        scoreText.text = String.Empty;
    }

    void OnDisable()
    {
        SliderManager.CalculateScore -= CalculateScore;
    }
}
