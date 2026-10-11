using UnityEngine;

public class ScoreCollider : MonoBehaviour {

  [SerializeField] private ScoreUI scoreUI;
  [SerializeField] private ScoreColliderPowerUpSpawn powerUpSpawn;

  private Animator animator;
  private BoxCollider2D platformCollider;
  private bool IsDestroyed = false;

  private void Awake() {
    platformCollider = GetComponent<BoxCollider2D>();
    animator = GetComponentInChildren<Animator>();

    scoreUI = FindFirstObjectByType<ScoreUI>();
    powerUpSpawn = FindFirstObjectByType<ScoreColliderPowerUpSpawn>();
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (IsDestroyed) return;
    if (collision.gameObject.CompareTag("Ball")) {
      DestroyBrick();
    }
  }

  private void OnTriggerEnter2D(Collider2D collider) {
    if (IsDestroyed) return;
    if (collider.gameObject.CompareTag("Projectile")) {
      DestroyBrick();
    }
  }

  private void DestroyBrick() {
    IsDestroyed = true;
    scoreUI.UpdateScore(100);

    platformCollider.enabled = false;

    animator.SetTrigger("Destruct");
    powerUpSpawn.ChanceToSpawn(transform.position, 1f);
    Destroy(gameObject, 0.25f);
  }
}
