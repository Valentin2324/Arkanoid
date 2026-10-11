using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour {

  [SerializeField] private float ballSpeed;
  [SerializeField] private float maxBounceAngle;
  [SerializeField] private Paddle paddle;
  [SerializeField] private AudioSource audioSource;
  [SerializeField] private AudioClip hitClipScore;
  [SerializeField] private AudioClip hitClipBounce;

  public Rigidbody2D ballRigBody;
  private FillBarManagerUI fillBarManagerUI;
  private SpriteRenderer spriteBall;

  private Coroutine ballRoutine;
  private Vector3 originalScale;
  private bool isPowerUpOn;

  private void Awake() {
    ballRigBody = GetComponent<Rigidbody2D>();
    spriteBall = GetComponentInChildren<SpriteRenderer>();
    
    fillBarManagerUI = FindFirstObjectByType<FillBarManagerUI>();
  }

  public void BallPhysics() {
    audioSource.PlayOneShot(hitClipBounce);

    float startPosDirection = 10f;
    float directionStartX = transform.position.x < paddle.transform.position.x ? -1f : 1f;
    ballRigBody.linearVelocity = new Vector2(startPosDirection * directionStartX, ballSpeed);
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.CompareTag("Player")) {
      audioSource.PlayOneShot(hitClipBounce);
      BounceFromPaddle(collision);
    }
    if (collision.gameObject.CompareTag("Wall")) {
      audioSource.PlayOneShot(hitClipBounce);
    }
    if (collision.gameObject.CompareTag("ScoreCollider")) {
      audioSource.PlayOneShot(hitClipScore);
    }
  }

  private void BounceFromPaddle(Collision2D collision) {
    float ballX = transform.position.x;
    float paddleX = collision.transform.position.x;

    float paddleWidth = collision.collider.bounds.size.x;

    float hitPosition = ballX - paddleX;
    float normalizedHit = hitPosition / (paddleWidth / 2f);

    normalizedHit = Mathf.Clamp(normalizedHit, -1f, 1f);

    Vector2 direction = new Vector2(normalizedHit * maxBounceAngle, 1f).normalized;

    ballRigBody.linearVelocity = direction * ballSpeed;
  }

  public void StartBallSizeAddPowerUp(float duration) {
    if (paddle.GetBallState()) { return; }

    if (ballRoutine != null) {
      StopCoroutine(ballRoutine);
      transform.localScale = originalScale;
    }
    isPowerUpOn = true;
    ballRoutine = StartCoroutine(BallAddRoutine(duration));
  }

  private IEnumerator BallAddRoutine(float duration) {
    originalScale = transform.localScale;

    transform.localScale = new Vector3(originalScale.x * 2f, originalScale.y * 2f, originalScale.z);

    yield return new WaitForSeconds(duration);

    transform.localScale = originalScale;
    ballRoutine = null;
    isPowerUpOn = false;
  }

  public bool GetBallPowerState() {
    return isPowerUpOn;
  }

  public void RemovePowerUp() {
    fillBarManagerUI.BallAddFillBar.RemoveFillBarVisuals();
    StopCoroutine(ballRoutine);
    transform.localScale = originalScale;
  }

  public SpriteRenderer GetSpriteBall() {
    return spriteBall;
  }
}
