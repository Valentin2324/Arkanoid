using UnityEngine;
using UnityEngine.SceneManagement;

public class GameQuitButton : MonoBehaviour {

  private void Update() {
    if (Input.GetKeyDown(KeyCode.Q)) {
      QuitLevelGame();
    }
  }
  
  public void QuitLevelGame() {
    LoadingScene.SCENE_TO_LOAD = "MenuScene";
    SceneManager.LoadScene("LoadingScene");
  }
}
