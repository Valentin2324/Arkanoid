using UnityEngine;

public class PowerUpSizeSub : MonoBehaviour {

  [SerializeField] private Paddle paddle;
  [SerializeField] private float powerUpDuration;
  [SerializeField] private AudioClip paddleSizeDownSFX;

  private FillBarManagerUI fillBarManagerUI;

  private void Awake() {
    paddle = FindFirstObjectByType<Paddle>();
    fillBarManagerUI = FindFirstObjectByType<FillBarManagerUI>();
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.CompareTag("Player")) {

      AudioSource.PlayClipAtPoint(paddleSizeDownSFX, Camera.main.transform.position);
      paddle.StartPaddleSubPowerUp(powerUpDuration);

      fillBarManagerUI.PaddleSubFillBar.StartFillBar(powerUpDuration);
      
      Destroy(gameObject);
    }
  }
}
