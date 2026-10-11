using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour {
  
  public static string SCENE_TO_LOAD = "MenuScene";

  [SerializeField] private float waitTimeBetweenScenes = 1.25f;

  private IEnumerator Start() {
    Time.timeScale = 1f;
    yield return new WaitForSeconds(waitTimeBetweenScenes);
    SceneManager.LoadScene(SCENE_TO_LOAD);
  }
}
