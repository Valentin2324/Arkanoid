using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlayButton : MonoBehaviour {
  
  public void StartGame() {
    LoadingScene.SCENE_TO_LOAD = "GameScene";
    SceneManager.LoadScene("LoadingScene");
  }
}
