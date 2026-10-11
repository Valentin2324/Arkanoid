using UnityEngine;

public class SolidCollider : MonoBehaviour  {

  [SerializeField] private SpriteRenderer solidSprite;
  [SerializeField] private SpriteRenderer damaged1Sprite;
  [SerializeField] private SpriteRenderer damaged2Sprite;
  [SerializeField] private ScoreUI scoreUI;
  [SerializeField] private ScoreColliderPowerUpSpawn powerUpSpawn;

  private bool isDestroyed = false;
  private int phaseNumber = 1;
  private Animator animator;

  private void Awake() {
    scoreUI = FindFirstObjectByType<ScoreUI>();
    powerUpSpawn = FindFirstObjectByType<ScoreColliderPowerUpSpawn>();

    animator = GetComponentInChildren<Animator>();
    solidSprite.enabled = true;
    damaged1Sprite.enabled = false;
    damaged2Sprite.enabled = false;
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (isDestroyed) return;

    if (collision.gameObject.CompareTag("Ball")) {
      SolidColliderDestroyCycle();
    }
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (isDestroyed) return;

    if (collision.gameObject.CompareTag("Projectile")) {
      SolidColliderDestroyCycle();
    }
  }

  private void SolidColliderDestroyCycle() {
    switch (phaseNumber) {
      case 1:
        solidSprite.enabled = false;
        damaged1Sprite.enabled = true;
        phaseNumber++;
        break;
      case 2:
        damaged1Sprite.enabled = false;
        damaged2Sprite.enabled = true;
        phaseNumber++;
        break;
      case 3:
        // Destruct Animation
        isDestroyed  = true;
        scoreUI.UpdateScore(250);
        animator.SetTrigger("OnThirdHit");

        powerUpSpawn.ChanceToSpawn(transform.position, 2f);

        Destroy(gameObject, 0.25f);
        break;
    }
  }
}
