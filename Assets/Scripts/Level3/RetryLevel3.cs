using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel3 : MonoBehaviour {
  [SerializeField] private GameOverUI gameOverUI;
  [SerializeField] private HighScoreUI highScoreUI;

  private void Update() {
    if (Input.GetKeyDown(KeyCode.R)) {
      RetryGame3();
    }
  }
  
  public void RetryGame3() {
    gameOverUI.HideGameOverUI();
    SceneManager.LoadScene("GameSceneLevel3");
    Time.timeScale = 1f;
    highScoreUI.UpdateStats();
  }
}
