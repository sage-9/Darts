using TMPro;
using UnityEngine;

public class PlayerScoreUI : MonoBehaviour
{
   [SerializeField] private TMP_Text playerName;
   [SerializeField] private TMP_Text playerScore;
   [SerializeField] private PlayerData player;

   void Awake()
   {
      player.OnScoreChanged += () => playerScore.text = player.PlayerScore.ToString();
   }

   void Start()
   {
      playerName.text = player.PlayerName;
      Debug.Log("the Player Name is " + player.PlayerName);
      playerScore.text = player.PlayerScore.ToString();
   }
   
}
