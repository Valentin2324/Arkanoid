using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButtonUI : MonoBehaviour  {

  [SerializeField] private GameOverUI gameOverUI;
  [SerializeField] private HighScoreUI highScoreUI;

  private void Update() {
    if (Input.GetKeyDown(KeyCode.R)) {
      RetryGame();
    }
  }
  
  public void RetryGame() {
    gameOverUI.HideGameOverUI();
    SceneManager.LoadScene("GameScene");
    Time.timeScale = 1f;
    highScoreUI.UpdateStats();
  }
}
