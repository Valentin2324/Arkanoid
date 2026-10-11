using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour {
  
  [SerializeField] private TextMeshProUGUI highScoreNumText;
  [SerializeField] private ScoreUI scoreUI;
  [SerializeField] private TextMeshProUGUI replayNumText;

  private int highScore;
  private int currentScore;
  private int replayNum;

  private void Start() {
    highScore = PlayerPrefs.GetInt("HighScore", 0);
    highScoreNumText.text = highScore.ToString();

    replayNum = PlayerPrefs.GetInt("Replay", 0);
    replayNumText.text = replayNum.ToString();
  }

  public void UpdateStats() {
    UpdateHighScore();
    UpdateReplays();
  }

  private void UpdateHighScore() {
    currentScore = scoreUI.GetScore();
    highScore = PlayerPrefs.GetInt("HighScore", 0);

    if (highScore < currentScore) {
      highScore = currentScore;
      PlayerPrefs.SetInt("HighScore", highScore);
      PlayerPrefs.Save();
    }

    highScoreNumText.text = highScore.ToString();
  }

  private void UpdateReplays() {
    replayNum++;
    PlayerPrefs.SetInt("Replay", replayNum);

    replayNumText.text = replayNum.ToString();
  }
}
