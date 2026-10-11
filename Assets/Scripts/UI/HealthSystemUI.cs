using UnityEngine;
using UnityEngine.UI;

public class HealthSystemUI : MonoBehaviour {

  [SerializeField] private Image health1;
  [SerializeField] private Image health2;
  [SerializeField] private Image health3;
  [SerializeField] private Paddle paddle;

  private void Awake() {
    health1.enabled = true;
    health2.enabled = false;
    health3.enabled = false;
  }
  
  public void AddHealthUI() {
    switch (paddle.GetHealthCount()) {
      case 1: health1.enabled = true; break;
      case 2: health2.enabled = true; break;
      case 3: health3.enabled = true; break;
    }
  }

  public void RemoveHealthUI() {
    switch (paddle.GetHealthCount()) {
      case 0: health1.enabled = false; break;
      case 1: health2.enabled = false; break;
      case 2: health3.enabled = false; break;
    }
  }
}
