using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGameButton : MonoBehaviour {
  
  public void ReloadGame() {
    if (Time.timeScale == 1f) {
      SceneManager.LoadScene("GameScene");
    }
  }

  public void ReloadLevel2() {
    if (Time.timeScale == 1f) {
      SceneManager.LoadScene("GameSceneLevel2");
    }
  }

  public void ReloadLevel3() {
    if (Time.timeScale == 1f) {
      SceneManager.LoadScene("GameSceneLevel3");
    }
  }
}
