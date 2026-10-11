using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueLevelButton : MonoBehaviour {

  [SerializeField] private HighScoreUI highScoreUI;

  private void Update() {
    if (Input.GetKeyDown(KeyCode.C)) {
      NextLevel();
    }
  }
  
  public void NextLevel() {
    LoadingScene.SCENE_TO_LOAD = "GameSceneLevel2";
    SceneManager.LoadScene("LoadingScene");
    highScoreUI.UpdateStats();
  }
}
