using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour {

  [SerializeField] private HighScoreUI highScoreUI;
  
  private void Update() {
    if (Input.GetKeyDown(KeyCode.P)) {
      PlayAgain();
    }
  }

  public void PlayAgain() {
    LoadingScene.SCENE_TO_LOAD = "GameScene";
    SceneManager.LoadScene("LoadingScene");
    highScoreUI.UpdateStats();
  }
}
