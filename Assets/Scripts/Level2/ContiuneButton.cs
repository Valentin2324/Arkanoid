using UnityEngine;
using UnityEngine.SceneManagement;

public class ContiuneButton : MonoBehaviour {
  [SerializeField] private HighScoreUI highScoreUI;

  private void Update() {
    if (Input.GetKeyDown(KeyCode.C)) {
      NextLevel();
    }
  }
  
  public void NextLevel() {
    LoadingScene.SCENE_TO_LOAD = "GameSceneLevel3";
    SceneManager.LoadScene("LoadingScene");
    highScoreUI.UpdateStats();
  }
}
