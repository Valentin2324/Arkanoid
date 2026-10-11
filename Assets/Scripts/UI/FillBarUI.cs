using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FillBarUI : MonoBehaviour {
  
  [SerializeField] private GameObject visualsUI;
  [SerializeField] private Image fillBar;
  
  private Coroutine fillRoutine;

  private void Awake() {
    RemoveFillBarVisuals();
  }

  public void StartFillBar(float duration) {
    if (fillRoutine != null) {
      StopCoroutine(fillRoutine);
    }

    visualsUI.SetActive(true);
    fillRoutine = StartCoroutine(ShowFillBarProgress(duration));
  }

  private IEnumerator ShowFillBarProgress(float duration) {
    float timeLeft = duration;

    while (timeLeft > 0) {
      timeLeft -= Time.deltaTime;
      fillBar.fillAmount = timeLeft / duration;

      yield return null;
    }
    
    fillBar.fillAmount = 0;
    RemoveFillBarVisuals();
  }

  public void RemoveFillBarVisuals() {
    visualsUI.SetActive(false);
  }

}
