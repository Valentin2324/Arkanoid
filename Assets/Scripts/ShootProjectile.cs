using UnityEngine;

public class ShootProjectile : MonoBehaviour {
  
  [SerializeField] private float projectileSpeedY;
  [SerializeField] private AudioClip projectileHitSFX;

  private Rigidbody2D projectileRigBody;

  private void Awake() {
    projectileRigBody = GetComponent<Rigidbody2D>();
  }

  private void Update() {
    projectileRigBody.linearVelocity = new Vector2(projectileRigBody.linearVelocity.x, projectileSpeedY);
  }

  private void OnTriggerEnter2D(Collider2D collider) {
    if (collider.gameObject.layer == LayerMask.NameToLayer("EnvironmentCollision")) {
      AudioSource.PlayClipAtPoint(projectileHitSFX, transform.position);
      Destroy(gameObject);
    }
  }
}
