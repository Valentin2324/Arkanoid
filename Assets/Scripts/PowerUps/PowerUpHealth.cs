using UnityEngine;

public class PowerUpHealth : MonoBehaviour {

  [SerializeField] private Paddle paddle;
  [SerializeField] private HealthSystemUI healthSystemUI;
  [SerializeField] private AudioClip heartPickUpSFX;

  private void Awake() {
    paddle = FindFirstObjectByType<Paddle>();
    healthSystemUI = FindFirstObjectByType<HealthSystemUI>();
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.CompareTag("Player")) {
      AudioSource.PlayClipAtPoint(heartPickUpSFX, Camera.main.transform.position);
      paddle.AddHealth();
      healthSystemUI.AddHealthUI();

      Destroy(gameObject);
    }
  }
}
