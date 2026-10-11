using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour {

  [SerializeField] private GameOverUI gameOverUI;
  [SerializeField] private HighScoreUI highScoreUI;

  private void Update() {
    if (Input.GetKeyDown(KeyCode.R)) {
      RetryLevel2();
    }
  }
  
  public void RetryLevel2() {
    gameOverUI.HideGameOverUI();
    SceneManager.LoadScene("GameSceneLevel2");
    Time.timeScale = 1f;
    highScoreUI.UpdateStats();
  }
}
