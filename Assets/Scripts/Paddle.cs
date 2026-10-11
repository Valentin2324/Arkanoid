using System.Collections;
using UnityEngine;

public class Paddle : MonoBehaviour {

  [SerializeField] private float movementSpeed;
  [SerializeField] private Ball ball;
  [SerializeField] private FillBarUI fillBarUIAdd;
  [SerializeField] private FillBarUI fillBarUISub;
  [SerializeField] private AudioSource audioSource;

  private Rigidbody2D playerRigBody;

  private Coroutine paddleSizeRoutine;
  private Vector3 normalScale;

  private bool isBallOn = true;
  private int healthCount = 1;
  private bool isGameOver = false;

  private void Awake() {
    playerRigBody = GetComponent<Rigidbody2D>();

    normalScale = transform.localScale;
  }   

  private void Update() {
    ControlPaddleLogic();
  }

  private void ControlPaddleLogic() {
    if (isGameOver) return;

    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
      playerRigBody.linearVelocity = new Vector2(-movementSpeed, playerRigBody.linearVelocity.y);

      if (!audioSource.isPlaying) {
        audioSource.Play();
      }
      
      if (isBallOn) {
        ball.ballRigBody.linearVelocity = new Vector2(-movementSpeed, ball.ballRigBody.linearVelocity.y);
      }
    }
    else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
      playerRigBody.linearVelocity = new Vector2(movementSpeed, playerRigBody.linearVelocity.y);

      if (!audioSource.isPlaying) {
        audioSource.Play();
      }

      if (isBallOn) {
        ball.ballRigBody.linearVelocity = new Vector2(movementSpeed, ball.ballRigBody.linearVelocity.y);
      }
    }
    else {
      playerRigBody.linearVelocity = new Vector2(0, playerRigBody.linearVelocity.y);

      if (audioSource.isPlaying) {
        audioSource.Stop();
      }

      if (isBallOn) {
        ball.ballRigBody.linearVelocity = new Vector2(0, ball.ballRigBody.linearVelocity.y);
      }
    }

    if (Input.GetKeyDown(KeyCode.Space) && isBallOn) {
      ball.BallPhysics();
      isBallOn = false;
    }
  }

  // Paddle PowerUp Sync Routine (fix)

  public void StartPaddleAddPowerUp(float duration) {
    StartPaddleSizePowerUp(duration, 1.5f);
  }

  public void StartPaddleSubPowerUp(float duration) {
    StartPaddleSizePowerUp(duration, 1f / 1.5f);
  }

  private void StartPaddleSizePowerUp(float duration, float scaleMultiplier) {
    if (paddleSizeRoutine != null) {
      StopCoroutine(paddleSizeRoutine);
      fillBarUIAdd.RemoveFillBarVisuals();
      fillBarUISub.RemoveFillBarVisuals();
    }

    transform.localScale = normalScale;
    paddleSizeRoutine = StartCoroutine(PaddleSizeRoutine(duration, scaleMultiplier));
  }

  private IEnumerator PaddleSizeRoutine(float duration, float scaleMultiplier) {
    transform.localScale = new Vector3(normalScale.x * scaleMultiplier, normalScale.y, normalScale.z);

    yield return new WaitForSeconds(duration);

    transform.localScale = normalScale;
    paddleSizeRoutine = null;
  }

  public void AddHealth() {
    if (healthCount < 3) {
      healthCount++;
    }
    else {
      Debug.Log("Max Health");
    }
  }

  public void SubHealth() {
    if (healthCount > 0) {
      healthCount--;
    }
  }

  public void ResetBallPosition() {
    isBallOn = true;

    ball.ballRigBody.linearVelocity = Vector2.zero;
    ball.ballRigBody.angularVelocity = 0f;

    ball.transform.position = transform.position + new Vector3(-0.7f, 0.8f, 0f);
  }

  public int GetHealthCount() {
    return healthCount;
  }

  public bool GetBallState() {
    return isBallOn;
  }

  public void SetGameOver() {
    isGameOver = true;
    audioSource.Stop();
  }
}
