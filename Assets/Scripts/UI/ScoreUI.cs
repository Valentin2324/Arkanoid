using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour {

  [SerializeField] private TextMeshProUGUI scoreText;
  [SerializeField] private TextMeshProUGUI hitColliderText;

  private int score = 0;
  private int hitColliderCounter = 0;

  public void UpdateScore(int amount) {
    score += amount;
    hitColliderCounter++;
    
    scoreText.text = score.ToString();
    hitColliderText.text = hitColliderCounter.ToString();
  }

  public int GetScore() {
    return score;
  }

  public int GetHits() {
    return hitColliderCounter;
  }
}
