using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]private Transform boardCentre;
    [SerializeField]private float boardRadius;
    private float _score;

    private int[] scoreSlices = { 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5 };

    void Awake()
    {
        SliderManager.CalculateScore += CalculateScore;
    }
    public void CalculateScore(Vector2 hitPosition)
    {
        // 1. Get local position relative to board center
        Vector2 localHit = hitPosition - (Vector2)boardCentre.position;
        float distance = localHit.magnitude;

        // 2. Check if it's off the board
        if (distance > boardRadius)
        {
            Debug.Log("Miss! Out of bounds.");
            return;
        }

        // 3. Calculate Angle (Degrees)
        // Unity's Atan2 returns radians. We convert to Degrees.
        // We add 90 because 0 degrees in Atan2 is "Right", but 20 is "Top".
        float angle = Mathf.Atan2(localHit.y, localHit.x) * Mathf.Rad2Deg;
        float adjustedAngle = (90f - angle + 360f) % 360f;

        // 4. Determine Slice (Each slice is 18 degrees)
        int sliceIndex = Mathf.FloorToInt((adjustedAngle + 9f) / 18f) % 20;
        int baseScore = scoreSlices[sliceIndex];

        // 5. Apply Multipliers based on distance
        // (You'll need to measure your specific sprite's ring distances)
        int finalScore = ApplyMultipliers(baseScore, distance);
        if (finalScore <= GameManager.Instance.currentPlayer.playerScore)
        {
            GameManager.Instance.currentPlayer.playerScore -= finalScore;
        }
        

        Debug.Log($"{GameManager.Instance.currentPlayer.name} final score:{finalScore} newScore:{GameManager.Instance.currentPlayer.playerScore} (Base: {baseScore}, Angle: {adjustedAngle}, Distance: {distance})");
    }

    private int ApplyMultipliers(int baseScore, float dist)
    {
        // Example logic:
        if ((dist/boardRadius) < 0.15f) return 50; // Bullseye
        if ((dist/boardRadius) < 0.35f) return 25; // Outer Bull
        
        // You would define your "Triple" and "Double" ring distances here
        // if (dist > tripleMin && dist < tripleMax) return baseScore * 3;
        
        return baseScore;
    }
}
