using System.Collections;
using TMPro;
using UnityEngine;

public class TurnAnnouncerUI : MonoBehaviour
{
    [SerializeField]private TMP_Text turnText;
    private string _playerName;
    [SerializeField]private GameObject turnAnnouncerPanel;
    public void OnCurrentPlayerChanged()
    {
        _playerName = GameManager.Instance.currentPlayer.PlayerName;
    }

    public void AnnounceTurn()
    {
       StartCoroutine(AnnounceTurnSequence());
    }

    IEnumerator AnnounceTurnSequence()
    {
        turnText.text = $"{_playerName}'s turn";
        turnAnnouncerPanel.SetActive(true);
        yield return new WaitForSeconds(1f); 
        turnAnnouncerPanel.SetActive(false);
    }
    
}
