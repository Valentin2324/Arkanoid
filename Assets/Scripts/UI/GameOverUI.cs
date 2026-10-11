using UnityEngine;

public class GameOverUI : MonoBehaviour {
  
  private void Awake() {
    HideGameOverUI();
  }

  public void ShowGameOverUI() {
    gameObject.SetActive(true);
  }

  public void HideGameOverUI() {
    gameObject.SetActive(false);
  }
}
