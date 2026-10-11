using UnityEngine;

public class PowerUpSizeBallAdd : MonoBehaviour {
  
  [SerializeField] private Ball ball;
  [SerializeField] private Paddle paddle;
  [SerializeField] private float powerUpDuration;
  [SerializeField] private AudioClip ballAddSizeSFX;

  private FillBarManagerUI fillBarManagerUI;

  private void Awake() {
    ball = FindFirstObjectByType<Ball>();
    paddle = FindFirstObjectByType<Paddle>();
    fillBarManagerUI = FindFirstObjectByType<FillBarManagerUI>();
  }

  private void OnTriggerEnter2D(Collider2D collider) {
    if (collider.gameObject.CompareTag("Player")) {
      AudioSource.PlayClipAtPoint(ballAddSizeSFX, Camera.main.transform.position);
      ball.StartBallSizeAddPowerUp(powerUpDuration);

      if (!paddle.GetBallState()) {
        fillBarManagerUI.BallAddFillBar.StartFillBar(powerUpDuration);
      }

      Destroy(gameObject);
    }
  }

}
