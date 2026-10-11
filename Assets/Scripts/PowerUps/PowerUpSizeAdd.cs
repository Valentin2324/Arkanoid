using UnityEngine;

public class PowerUpSizeAdd : MonoBehaviour {
  
  [SerializeField] private Paddle paddle;
  [SerializeField] private float powerUpDuration;
  [SerializeField] private AudioClip paddleAddSFX;

  private FillBarManagerUI fillBarManagerUI;

  private void Awake() {
    paddle = FindFirstObjectByType<Paddle>();
    fillBarManagerUI = FindFirstObjectByType<FillBarManagerUI>();
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.CompareTag("Player")) {
      AudioSource.PlayClipAtPoint(paddleAddSFX, Camera.main.transform.position);
      paddle.StartPaddleAddPowerUp(powerUpDuration);

      fillBarManagerUI.PaddleAddFillBar.StartFillBar(powerUpDuration);

      Destroy(gameObject);
    }
  }
}
