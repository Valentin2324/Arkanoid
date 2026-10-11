using UnityEngine;

public class DeathZoneCollider : MonoBehaviour  {

  [SerializeField] private HealthSystemUI healthSystemUI;
  [SerializeField] private Paddle paddle;
  [SerializeField] private Ball ball;
  [SerializeField] private GameOverUI gameOverUI;
  [SerializeField] private AudioSource loseHealthSource;
  [SerializeField] private AudioClip loseHealthClip;
  [SerializeField] private AudioSource gameOverSource;
  [SerializeField] private AudioClip gameOverClip;

  private void OnTriggerEnter2D(Collider2D collider) {
    if (collider.gameObject.CompareTag("Ball")) {
      if (paddle.GetHealthCount() > 0) {
        loseHealthSource.PlayOneShot(loseHealthClip);

        paddle.SubHealth();
        healthSystemUI.RemoveHealthUI();
        paddle.ResetBallPosition();
        if (ball.GetBallPowerState()) {
          ball.RemovePowerUp();
        }
      }
      else {
        gameOverSource.PlayOneShot(gameOverClip);
        paddle.SetGameOver();
        gameOverUI.ShowGameOverUI();
        Time.timeScale = 0f;
      }
    }
    else if (collider.gameObject.CompareTag("PowerUp")) {
      Destroy(collider.gameObject);
    }
  }
}
