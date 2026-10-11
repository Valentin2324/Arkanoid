using UnityEngine;

public class WinLevel3Panel : MonoBehaviour {
  private const int SCORE_COLLIDERS_STAGE_III = 146;
  
  [SerializeField] private ScoreUI scoreUI;
  [SerializeField] private Ball ball;
  [SerializeField] private GameObject WinPanel;
  [SerializeField] private AudioSource audioWinSFX;
  [SerializeField] private AudioClip winSFX;

  private bool isPanelOn = false;

  private void Awake() {
    HideWinStageUI();
  }

  private void Update() {
    if (!isPanelOn) {
      ShowWinStageUI();
    }
  }

  private void ShowWinStageUI() {
    if (scoreUI.GetHits() >= SCORE_COLLIDERS_STAGE_III) {
      WinPanel.SetActive(true);
      ball.GetSpriteBall().enabled = false;
      ball.ballRigBody.simulated = false;
      ball.ballRigBody.linearVelocity = Vector2.zero;
      isPanelOn = true;
      audioWinSFX.PlayOneShot(winSFX);
    }
  }

  private void HideWinStageUI() {
    WinPanel.SetActive(false);
  }
}
