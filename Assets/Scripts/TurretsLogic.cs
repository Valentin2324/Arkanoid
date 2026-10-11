using System.Collections;
using TMPro;
using UnityEngine;

public class TurretsLogic : MonoBehaviour  {

  [SerializeField] private float shootDelayOn;
  [SerializeField] private float shootDelayOff;
  [SerializeField] private SpriteRenderer shootEffectLeft;
  [SerializeField] private SpriteRenderer shootEffectRight;

  [SerializeField] private GameObject projectilePrefab;
  [SerializeField] private Transform shootPointLeft;
  [SerializeField] private Transform shootPointRight;

  [SerializeField] private TextMeshProUGUI turretsPowerUpMultipliyerText;
  [SerializeField] private AudioSource shootEffectSFX;
  [SerializeField] private AudioClip shootClip;
  
  private SpriteRenderer[] sprites;
  private Collider2D[] colliders;

  private Coroutine turretsRoutine;
  private int addMultiplyier = 1;

  private void Awake() {
    sprites = GetComponentsInChildren<SpriteRenderer>();
    colliders = GetComponentsInChildren<Collider2D>();

    shootEffectSFX = GetComponentInChildren<AudioSource>();
  
    DisableTurrets();
  }

  private void DisableTurrets() {
    foreach (SpriteRenderer sprite in sprites) {
      sprite.enabled = false;
    }
    foreach (Collider2D collider in colliders) {
      collider.enabled = false;
    }
  }

  private void AddMultypliyerTextTurretsPowerUp() {
    addMultiplyier++;
    turretsPowerUpMultipliyerText.text = "x" + addMultiplyier.ToString();
  }

  public void StartTurretsRoutine(float duration) {
    if (turretsRoutine != null) {
      StopCoroutine(turretsRoutine);
      AddMultypliyerTextTurretsPowerUp();
    }

    turretsRoutine = StartCoroutine(TurretsRoutine(duration));
  }

  private IEnumerator TurretsRoutine(float duration) {
    for (int i = 0; i < 2; i++) {
      sprites[i].enabled = true;
    }
    for (int i = 0; i < 2; i++) {
      colliders[i].enabled = true;
    }

    TurretsShoot(duration);

    yield return new WaitForSeconds(duration);

    DisableTurrets();
    turretsRoutine = null;

    addMultiplyier = 1;
  }

  private void TurretsShoot(float powerUpDuration) {
    StartCoroutine(ShootEffectToggle(powerUpDuration));
  }

  private IEnumerator ShootEffectToggle(float duration) {
    float endTime = Time.time + duration;
    while (Time.time < endTime) {
      shootEffectLeft.enabled = true;
      shootEffectRight.enabled = true;

      ShootProjectiles();

      shootEffectSFX.PlayOneShot(shootClip);

      yield return new WaitForSeconds(shootDelayOn);

      shootEffectLeft.enabled = false;
      shootEffectRight.enabled = false;

      yield return new WaitForSeconds(shootDelayOff);
    }

    if (addMultiplyier > 1) {
      addMultiplyier--;
      turretsPowerUpMultipliyerText.text = "x" + addMultiplyier.ToString();
    }
  }

  private void ShootProjectiles() {
    Instantiate(projectilePrefab, shootPointLeft.position, Quaternion.identity);
    Instantiate(projectilePrefab, shootPointRight.position, Quaternion.identity);
  }
}
